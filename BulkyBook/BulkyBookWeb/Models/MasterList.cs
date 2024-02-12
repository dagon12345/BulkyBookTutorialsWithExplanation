using Google.Protobuf.WellKnownTypes;
using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookWeb.Models
{
    public class MasterList
    {
        [Key]
        public int ID { get; set; }
        public string ?LastName { get; set; }
        public string ?FirstName { get; set; }
        public string ?MiddleName { get; set; }
        public string ?ExtName { get; set; }
        public string ?Citizenship { get; set; }
        public string ?MothersMaiden { get; set; }
        public int ?PSGCRegion { get; set; }
        public int ?PSGCProvince { get; set; }
        public int ?PSGCCityMun { get; set; }
        public int ?PSGCBrgy { get; set; }
        public string ?Address { get; set; }
        public DateTime ?BirthDate { get; set; }
        public int ?SexID { get; set; }
        public int ?MaritalStatusID { get; set; }
        public string ?Religion { get; set; }
        public string ?BirthPlace { get; set; }
        public string ?EducAttain { get; set; }
        public int ?IDTypeID { get; set; }
        public string ?IDNumber { get; set; }
        public DateTime ?IDDateIssued { get; set; }
        public int ?Pantawid { get; set; }
        public int ?Indigenous { get; set; }
        public string ?SocialPensionID { get; set; }
        public string ?HouseholdID { get; set; }
        public string ?ContactNum { get; set; }
        public int ?HealthStatusID { get; set; }
        public string ?HealthStatusRemarks { get; set; }
        [NotMapped]
        public Timestamp? DateTimeEntry { get; set; }
        public string ?EntryBy { get; set; }
        public int ?DataSourceID { get; set; }
        public int ?StatusID { get; set; }
        public string ?Remarks { get; set; }
        public int ?RegTypeID { get; set; }
        public string ?InclusionBatch { get; set; }
        public DateTime ?InclusionDate { get; set; }
        public string ?ExclusionBatch { get; set; }
        public DateTime ?ExclusionDate { get; set; }
        public string ?DateDeceased { get; set; }
        [NotMapped]
        public Timestamp ?DateTimeModified { get; set; }
        public string ?ModifiedBy { get; set; }
        [NotMapped]
        public Timestamp ?DateTimeDeleted { get; set; } 
        public string ?DeletedBy { get; set; }
        public int ?WaitlistedReportID { get; set; }
        public int ?WithPhoto { get; set; }
    }
}
