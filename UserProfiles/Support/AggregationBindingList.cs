// Binding to Properties on Aggregated Objects
// Bradley Smith - 2010/11/21

using System;
using System.Collections.Generic;
using System.ComponentModel;

//This has been inspired from an article on the web to use aggregate bindings

namespace UserProfiles
{
    /// <summary>
    /// <para>Represents a strongly typed list of objects that can be accessed by 
    /// index. When used as a binding source, exposes the properties on the 
    /// objects aggregated by the list items.</para>
    /// <para>Aggregated property names are separated by the pointer-to-member 
    /// symbol '->' (e.g. 'ParentProp->ChildProp').</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AggregationBindingList<T> : List<T>, ITypedList
    {

        const int MAX_RECURSION = 10;

        /// <summary>
        /// Initializes a new instance of the AggregationBindingList&lt;T&gt; class 
        /// that is empty and has the default initial capacity.
        /// </summary>
        public AggregationBindingList() : base() { }

        /// <summary>
        /// Initializes a new instance of the AggregationBindingList&lt;T&gt; class 
        /// that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">Initial capacity of the list.</param>
        public AggregationBindingList(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes a new instance of the AggregationBindingList&lt;T&gt; class 
        /// that contains elements copied from the specified collection and 
        /// has sufficient capacity to accommodate the number of elements 
        /// copied.
        /// </summary>
        /// <param name="range">Sequence of elements to copy to the list.</param>
        public AggregationBindingList(IEnumerable<T> range) : base(range) { }

        /// <summary>
        /// Returns a collection of PropertyDescriptor objects for the 
        /// properties of <typeparamref name="T"/>, plus all properties on 
        /// aggregated objects.
        /// </summary>
        /// <param name="listAccessors">Ignored by this implementation.</param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(null);

            // we are only concerned with browsable properties
            Attribute[] attributes = new Attribute[] { new BrowsableAttribute(true) };

            // get PropertyDescriptor objects for T and all properties on aggregated objects (recursively)
            foreach (PropertyDescriptor property in GetPropertiesRecursive(typeof(T), null, attributes, 1))
            {
                pdc.Add(property);
            }

            return pdc;
        }

        /// <summary>
        /// Recursive iterator block to get the properties on aggregated objects.
        /// </summary>
        /// <param name="t">Type from which to get properties.</param>
        /// <param name="parent">Owning property (or null if belonging to <typeparamref name="T"/>).</param>
        /// <param name="attributes">Attribute filter.</param>
        /// <param name="depth">Depth of recursion.</param>
        /// <returns></returns>
        IEnumerable<PropertyDescriptor> GetPropertiesRecursive(Type t, PropertyDescriptor parent, Attribute[] attributes, int depth)
        {
            // self-referencing properties can cause infinite recursion, so place a cap on the depth of recursion
            if (depth >= MAX_RECURSION) yield break;

            // get the properties of the current Type
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(t, attributes))
            {
                if (parent == null)
                {
                    // property belongs to root type, return as-is
                    yield return property;
                }
                else
                {
                    // property is on an aggregated object, wrap and return
                    yield return new AggregatedPropertyDescriptor(parent, property, attributes);
                }

                // repeat for all properties belonging to this property
                foreach (PropertyDescriptor aggregated in GetPropertiesRecursive(property.PropertyType, parent, attributes, depth + 1))
                {
                    yield return new AggregatedPropertyDescriptor(property, aggregated, attributes);
                }
            }
        }

        /// <summary>
        /// Obsolete; legacy interface member from .NET 1.0
        /// </summary>
        /// <param name="listAccessors">Ignored by this implementation.</param>
        /// <returns></returns>
        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return GetType().Name;
        }

    }

    /// <summary>
    /// Describes a property which belongs to another property, and whose value 
    /// is accessed/changed from the context of that property.
    /// </summary>
    public class AggregatedPropertyDescriptor : PropertyDescriptor
    {

        /// <summary>
        /// Gets the type of the component this property is bound to.
        /// </summary>
        public override Type ComponentType
        {
            get
            {
                return AggregatedProperty.ComponentType;
            }
        }
        /// <summary>
        /// Gets the PropertyDescriptor object wrapped by this instance.
        /// </summary>
        public PropertyDescriptor AggregatedProperty { get; private set; }
        /// <summary>
        /// Gets a value indicating whether this property is read-only.
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                return AggregatedProperty.IsReadOnly;
            }
        }
        /// <summary>
        /// Gets the PropertyDescriptor object which owns this property.
        /// </summary>
        public PropertyDescriptor OwningProperty { get; private set; }
        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        public override Type PropertyType
        {
            get
            {
                return AggregatedProperty.PropertyType;
            }
        }

        /// <summary>
        /// Initializes a new instance of the AggregatedPropertyDescriptor class, 
        /// given the owning property, the PropertyDescriptor instance being 
        /// wrapped and an attribute filter.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="aggregated"></param>
        /// <param name="attributes"></param>
        public AggregatedPropertyDescriptor(PropertyDescriptor owner, PropertyDescriptor aggregated, Attribute[] attributes)
            : base(owner.Name + "->" + aggregated.Name, attributes)
        {
            OwningProperty = owner;
            AggregatedProperty = aggregated;
        }

        /// <summary>
        /// Returns whether resetting an object changes its value.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public override bool CanResetValue(object component)
        {
            return AggregatedProperty.CanResetValue(component);
        }

        /// <summary>
        /// Gets the current value of the property on a component, redirecting 
        /// the call to the appropriate object.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public override object GetValue(object component)
        {
            return AggregatedProperty.GetValue(OwningProperty.GetValue(component));
        }

        /// <summary>
        /// Resets the value for this property of the component to its default 
        /// value.
        /// </summary>
        /// <param name="component"></param>
        public override void ResetValue(object component)
        {
            AggregatedProperty.ResetValue(component);
        }

        /// <summary>
        /// Sets the value of the component to a different value, redirecting 
        /// the call to the appropriate object.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="value"></param>
        public override void SetValue(object component, object value)
        {
            AggregatedProperty.SetValue(OwningProperty.GetValue(component), value);
        }

        /// <summary>
        /// Determines whether the value of this property should be serialized.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public override bool ShouldSerializeValue(object component)
        {
            return AggregatedProperty.ShouldSerializeValue(component);
        }
    }
}