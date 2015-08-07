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
    
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Artisticworks = new HashSet<Artisticworks>();
            this.AssociationEvent = new HashSet<AssociationEvent>();
            this.AssociationHistory = new HashSet<AssociationHistory>();
            this.AssociationRule = new HashSet<AssociationRule>();
            this.AwardRecord = new HashSet<AwardRecord>();
            this.ExhibitionRecord = new HashSet<ExhibitionRecord>();
            this.LatestNews = new HashSet<LatestNews>();
            this.MediaReports = new HashSet<MediaReports>();
            this.PositionRecord = new HashSet<PositionRecord>();
            this.ResearchFieldRecord = new HashSet<ResearchFieldRecord>();
        }
    
        public int Member_ID { get; set; }
        public string Member_Name { get; set; }
        public string Member_Mobile { get; set; }
        public string Member_Addresszip { get; set; }
        public string Member_Address { get; set; }
        public string Member_Picture { get; set; }
        public string Member_Email { get; set; }
        public string Member_Nowposition { get; set; }
        public string Member_Account { get; set; }
        public string Member_Password { get; set; }
        public string Member_Education { get; set; }
        public string Member_Experience { get; set; }
        public string Member_Adminname { get; set; }
        public string Member_Adminpasswd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artisticworks> Artisticworks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociationEvent> AssociationEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociationHistory> AssociationHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssociationRule> AssociationRule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AwardRecord> AwardRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExhibitionRecord> ExhibitionRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LatestNews> LatestNews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediaReports> MediaReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PositionRecord> PositionRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResearchFieldRecord> ResearchFieldRecord { get; set; }
    }
}
