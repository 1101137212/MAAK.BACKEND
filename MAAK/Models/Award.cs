//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MAAK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Award
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Award()
        {
            this.AwardRecord = new HashSet<AwardRecord>();
        }
    
        public int Award_ID { get; set; }
        public string Award_Title { get; set; }
        public string Award_Detail { get; set; }
        public string Award_Picture { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AwardRecord> AwardRecord { get; set; }
    }
}