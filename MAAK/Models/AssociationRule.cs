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
    
    public partial class AssociationRule
    {
        public int AssociationRule_ID { get; set; }
        public string AssociationRule_Title { get; set; }
        public string AssociationRule_Detail { get; set; }
        public int AssociationRule_Modifier { get; set; }
        public Nullable<System.DateTime> AssociationRule_Modificationdatetime { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
