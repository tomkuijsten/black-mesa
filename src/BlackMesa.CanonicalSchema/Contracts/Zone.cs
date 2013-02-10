using System;
using System.Runtime.Serialization;

namespace BlackMesa.CanonicalSchema.Contracts
{
    /// <summary>
    /// Represents a drink zone.
    /// </summary>
    [DataContract()]
    public class Zone : IExtensibleDataObject
    {
        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember()]
        public Person Persons { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
