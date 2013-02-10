using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlackMesa.CanonicalSchema.Contracts
{
    /// <summary>
    /// Represents a real person.
    /// A person may own multiple mugs and be part of multiple zones.
    /// </summary>
    [DataContract()]
    public class Person : IExtensibleDataObject
    {
        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember()]
        public IEnumerable<Zone> Zones { get; set; }
        [DataMember()]
        public IEnumerable<Mug> Mugs { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
