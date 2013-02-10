using System;
using System.Runtime.Serialization;

namespace BlackMesa.CanonicalSchema.Contracts
{
    /// <summary>
    /// Represents a physical mug.
    /// A mug can only be owned by one Person and a mug may not be owned by a Person.
    /// </summary>
    [DataContract()]
    public class Mug : IExtensibleDataObject
    {
        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        /// <summary>
        /// The value may be empty when a mug does not have an owner.
        /// </summary>
        [DataMember()]
        public Person Owner { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
