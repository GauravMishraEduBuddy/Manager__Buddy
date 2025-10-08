using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Security.Policy;

namespace EduBuddyApp.Models
{
    public class FeeItemGroup
    {
        public int FeeItemGroupId { get; set; }
        [Required, StringLength(255)]
        public string GroupName { get; set; }
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<FeeItem> FeeItems { get; set; } = new List<FeeItem>();
    }

    public class FeeItem
    {
        public int FeeItemId { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(255, ErrorMessage = "The name must be less than 255 characters.")]
        public string FeeItemName { get; set; } // e.g., Tuition, Lab Fee
                                                // public decimal Amount { get; set; } Not Needed, in FeeRecrods
       public int SchoolID { get; set; }
        public bool IsDiscountAllowed { get; set; }

       public bool IsCommonforAll { get; set; }
       public StudentTypeFilter? StudentFilter { get; set; }
        public int? FeeItemGroupId { get; set; }
        public bool AllowDirectAddition { get; set; } // New property
        public bool IsTransportHead { get; set; } // New property for Transport Head
        public bool IsHostelHead { get; set; } // New property for Hostel Head
        public bool IsPriority { get; set; } // New property for Priority Fee Items
        public int FeeItemOrder { get; set; } // New property for ordering fee items

        // Navigation properties
        public virtual School School { get; set; }
        // Navigation property for associated fines
        public virtual ICollection<FeeFine> FeeFines { get; set; } = new List<FeeFine>();
        public virtual FeeItemGroup? FeeItemGroup { get; set; }
    }
    public class FeeItemViewModel
    {
        public int FeeItemId { get; set; }
        [StringLength(255, ErrorMessage = "The name must be less than 255 characters.")]
        public string FeeItemName { get; set; } // e.g., Tuition, Lab Fee
       
        public bool IsDiscountAllowed { get; set; }
        public bool IsCommonforAll { get; set; }
        public decimal FeeAmount { get; set; }
        public string? AcademicSessionName { get; set; }
        public StudentTypeFilter? StudentFilter { get; set; }
        //public int? AcademicSessionId { get; set; }

    }
    public class FeeRecord
    {
        public int FeeRecordId { get; set; }
        [Required(ErrorMessage = "Please select an Academic Session.")]
        public int? AcademicSessionId { get; set; }
        //[Required(ErrorMessage = "Please select a Student")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please select a Fee Item.")]
        public int? FeeItemId { get; set; }
        [Required(ErrorMessage = "Please enter the amount due.")]
        public decimal AmountDue { get; set; }
        public decimal? Discount { get; set; } // Discount or exemption amount
        //public decimal? FineAmount { get; set; }
        [StringLength(255, ErrorMessage = "The name must be less than 255 characters.")]
        public string? DiscountComments { get; set; }
        public decimal NetAmountDue => AmountDue - (Discount ?? 0); // Net amount due after discount
        //public int SchoolID { get; set; }
        public decimal? AmountPaid { get; set; } //Amount Paid, can calculate Pending
        public bool ToAddNewAdmission { get; set; }
        public string? FeeRecordEditHistory { get; set; }
        public bool IsFineExempt { get; set; } // New property for specific fine exemption at the fee record level

        //Audit
        public DateTime? EditTime { get; set; }

        // Fine-related properties
        public decimal FineDue { get; set; } // Total fine amount accrued
        public decimal FinePaid { get; set; } // Total fine amount paid

        [NotMapped]
        //pending fine=>FineDue- FinePaid
        public decimal PendingFine => FineDue - FinePaid;


        [NotMapped]
        public decimal DiscountPercentage { get; set; } // This will not be saved to the database

        [NotMapped]
        public decimal PendingAmount
        {
            get
            {
                // Ensure AmountDue and Discount are not null
                decimal amountDue = AmountDue;
                decimal discount = Discount ?? 0;

                // Ensure ReceiptDetails is not null before summing
                decimal amountPaid = ReceiptDetails?.Sum(rd => rd.Amount) ?? 0;

                return amountDue - discount - amountPaid + FineDue - FinePaid;
            }
        }


        [NotMapped]
        public decimal? FineAmount
        {
            get
            {
                // Ensure FeeItem and FeeFines are not null
                if (FeeItem == null || FeeItem.FeeFines == null || !FeeItem.FeeFines.Any())
                {
                    return 0;
                }

                // Find the applicable fine based on EffectiveDate
                var applicableFine = FeeItem.FeeFines
                    .Where(f => f.IsInUse && f.EffectiveDate.Date <= DateTime.Now.Date)
                    .OrderByDescending(f => f.EffectiveDate)
                    .FirstOrDefault();

                // If no applicable fine is found, return 0
                if (applicableFine == null)
                {
                    return 0;
                }

                // Convert nullable values to non-nullable for calculation
                decimal balance = PendingAmount;

                // If there is no balance remaining, no fine is applied
                if (balance <= 0)
                {
                    return 0;
                }

                // Determine the end date for fine calculation
                DateTime fineEndDate = applicableFine.FineEndDate.HasValue
                    ? applicableFine.FineEndDate.Value.Date
                    : DateTime.Now.Date;

                // Calculate the number of days late since the fine's effective date until FineEndDate or Today
                DateTime fineStartDate = applicableFine.EffectiveDate.Date;
                int daysLate = (fineEndDate - fineStartDate).Days;

                // Ensure the daysLate is at least zero (no negative durations)
                if (daysLate < 0)
                {
                    return 0;
                }

                // Calculate the total fine amount
                decimal totalFine = daysLate * applicableFine.FineAmountPerDay;

                // Return the total fine amount
                return totalFine > 0 ? totalFine : 0; // Ensure fine is non-negative
            }
        }

        //[NotMapped]
        //public decimal? CalculatedFineAmount { get; set; } // Mutable property to store calculated fine amount

        // Navigation properties
        public virtual AcademicSession AcademicSession { get; set; }
        public virtual Student Student { get; set; }
        public virtual FeeItem FeeItem { get; set; }
        //public virtual School School { get; set; }
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
       // public ICollection<FeeFine> FeeFines { get; set; }


    }
    //this has to be created in DBase
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal TotalAmount { get; set; } // Total amount paid
        //public int SchoolID { get; set; }
        public int StudentID { get; set; }
        public int TransferTypeId { get; set; }
        [StringLength(50, ErrorMessage = "TransactionId must be less than 50 characters.")]
        public string? TransactionId { get; set; } // Transaction ID from the payment gateway
        public string? TransferDetails { get; set; }
        public bool TransferClear { get; set; } // Indicates if the payment cleared
        public bool IsTransactionSuccessful { get; set; } // Status of the transaction
        public string? FailureReason { get; set; } // Reason for failed transaction
        public string? Comments { get; set; }
        public Int16? ReceiptNo { get; set; }
        //Audit Trails
        [StringLength(50, ErrorMessage = "CreatedBy must be less than 50 characters.")]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(50, ErrorMessage = "ModifiedB must be less than 50 characters.")]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ReceiptDetailsString { get; set; }
        public void UpdateReceiptDetailsString()
        {
            if (ReceiptDetails != null && ReceiptDetails.Any())
            {
                var detailsList = ReceiptDetails.Select(detail =>
                    $"{detail.ReceiptDetailId}:{detail.FeeRecordId}:{detail.Amount}");

                ReceiptDetailsString = string.Join("|", detailsList);
            }
        }


        // Navigation properties
        //public virtual School School { get; set; }
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
        public virtual TransferType TransferType { get; set; }
        public virtual Student Student { get; set; }
    }
    public class ReceiptDetail
    {
        public int ReceiptDetailId { get; set; }
        public int ReceiptId { get; set; }
        public int FeeRecordId { get; set; }
        public decimal Amount { get; set; }
        //Audit Trails
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ReceiptDetailsComments { get; set; }

        // Navigation properties
        public virtual Receipt Receipt { get; set; }
        public virtual FeeRecord FeeRecord { get; set; }
    }
    public class TransferType
    {

        public int TransferTypeId { get; set; }
        
        [Required(ErrorMessage = "Transfer Type is required.")]
        [StringLength(255, ErrorMessage = "Transfer Type must be less than 255 characters.")]
        public string TransferTypeName { get; set; } // e.g., Credit Card, Bank Transfer, etc.
        public int SchoolID { get; set; }
        public bool Discontinued { get; set; } // Indicates if the transfer type is discontinued

        // Navigation properties
        public virtual School School { get; set; }
        public virtual ICollection<Receipt>? Receipts { get; set; }
    }

    public class StudentDiscount
    {
        public int StudentDiscountId { get; set; }
        public int StudentId { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public bool IsPercentage { get; set; }
        public string? DiscountComments { get; set; }
        public int AcademicSessionId { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50, ErrorMessage = "CreatedBy must be less than 50 characters.")]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual AcademicSession AcademicSession { get; set; }

    }



    /* 
     Fee ViewModels
     */
    public class FeeRecordViewModel
    {
        public int SectionId { get; set; }
        public int FeeItemId { get; set; }
        public decimal Amount { get; set; }
        public bool MakeChangesToExisting { get; set; }
        public int AcademicSessionId { get; set; } 
        //public bool AddtoNewAdmissionsOnly { get; set; }
        public StudentTypeFilter StudentFilter { get; set; }

    }
    public enum StudentTypeFilter
    {
        All,
        OnlyNewStudents,
        OnlyOldStudents
    }
    public class FeeRecordViewAgain
    {
        public int? FeeRecordId { get; set; }
        public int? AcademicSessionId { get; set; }
        public string? AcademicSessionName { get; set; }
        public bool AcademicSessionIsOpen { get; set; }
        public int? StudentId { get; set; }
        public int? FeeItemId { get; set; }
        public string? FeeItemName { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? Discount { get; set; } // Discount or exemption amount
        public string? DiscountComments { get; set; }
       // public decimal? FineAmount { get; set; } // Fine amount
        public decimal? FineDue { get; set; }
        public decimal? FinePaid { get; set; }
        //FinePending=>FineDue-FinePaid
        // Calculated property to get the pending fine amount
        public decimal FinePending => (FineDue ?? 0) - (FinePaid ?? 0);

        //public int SchoolID { get; set; }
        public decimal? AmountPaid { get; set; } //Amount Paid, can calculate Pending
        public decimal? PendingAmount => (AmountDue ?? 0) - (Discount ?? 0) - (AmountPaid ?? 0) 
            + (FineDue?? 0) - (FinePaid??0); // Computed property for pending amount
        public FeeItem? FeeItem { get; set; }
    }
    public class FeeRecordViewforReport
    {
        public int? FeeRecordId { get; set; }
        public int? AcademicSessionId { get; set; }
        public string? AcademicSessionName { get; set; }
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public bool? IsStudying { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }

        public int? FeeItemId { get; set; }
        public string? FeeItemName { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? Discount { get; set; } // Discount or exemption amount
        public string? DiscountComments { get; set; }
        //public int SchoolID { get; set; }
        public decimal? AmountPaid { get; set; } //Amount Paid, can calculate Pending
        //public decimal? FineAmount { get; set; } // Fine amount
        public decimal? FineDue { get; set; }
        public decimal? FinePaid { get; set; }        

        public decimal FinePending => (FineDue ?? 0) - (FinePaid ?? 0);
        public decimal? PendingAmount => (AmountDue ?? 0) - (Discount ?? 0) - (AmountPaid ?? 0) + (FineDue ?? 0) - (FinePaid ?? 0); // Computed property for pending amount
        public FeeItem? FeeItem { get; set; }
    }

    public class ReceiptCreationViewModel
    {
        public List<ReceiptDetailLineModel> FeeRecordLines { get; set; } = new List<ReceiptDetailLineModel>();
        public decimal RunningTotal => FeeRecordLines.Sum(line => line.Amount);

        // Add other properties as needed for the receipt
        public int StudentId { get; set; }
        public DateTime? ReceiptDate { get; set; }

        public double? TotalAmount { get; set; } // Total amount paid
        //public int SchoolID { get; set; }
        [Required(ErrorMessage = "Transfer Type is required.")]
        public int? TransferTypeId { get; set; }

        public string? TransactionId { get; set; } // Transaction ID from the payment gateway
        public string? TransferDetails { get; set; }

        public string? Comments { get; set; }
        public Int16? ReceiptNo { get; set; }
        // ... other properties ...
    }
    public class ReceiptDetailLineModel
    {
        public int FeeRecordId { get; set; }
        public decimal Amount { get; set; }

        // A list to hold fee record options (ID and Text)
        public List<FeeRecordOption>? FeeRecordOptions { get; set; } = new List<FeeRecordOption>();
        public string? FeeItemName { get; set; } // New property for FeeItem.Name

    }
    public class FeeRecordOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class ReceiptViewModel
    {
        public int ReceiptId { get; set; }   
        //public DateTime ReceiptDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? ReceiptDateOnly { get; set; }
        public decimal TotalAmount { get; set; } // Total amount paid
        public int StudentID { get; set; }
        public string? ExternalStudentID { get; set; }
        public string? StudentDetails { get; set; }
        public string? StudentName { get; set; }
        public string? SchoolName { get; set; }
        public string? FatherName { get; set; }
        //public string? StudentClassDetails { get; set; }
        public bool? IsStudying { get; set; }
        public bool IsNewStudent { get; set; } // Indicates if the student is a new admission
        public string? CLassDetails { get; set; }
        public string? SchoolClassName { get; set; }
        public string? SectionName { get; set; }
        public string? StudentEmail { get; set; }
        public string? FatherEmail { get; set; }
        public string? StudentPassword { get; set; }
        public string? TransferTypeName { get; set; }
        public int? TransferTypeId { get; set; }
        public string? TransactionId { get; set; } // Transaction ID from the payment gateway
        public string? TransferDetails { get; set; }
        public bool TransferClear { get; set; } // Indicates if the payment cleared
        public bool IsTransactionSuccessful { get; set; } // Status of the transaction
        public string? FailureReason { get; set; } // Reason for failed transaction
        public string? Comments { get; set; }
        public Int16? ReceiptNo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<string>? FeeDetails { get; set; }
        public string? FeeDetailsString { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ContactNumber { get; set; }
        public string? FeeItemName { get; set; }
        public decimal? Amount { get; set; }
        public int? ReceiptDetailId { get; set; }
        public List<ReceiptDetailView>? ReceiptDetails { get; set; } = new List<ReceiptDetailView>();

    }
    public class ReceiptDetailView
    {
        public int? ReceiptDetailId { get; set; }
        public int? ReceiptId { get; set; }
        public int? FeeRecordId { get; set; }
        public string? FeeItemName { get; set; }
        public decimal? Amount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class StudentFeeMatrixViewModel
    {
        public int StudentId { get; set; }
        public string? ExternalStudentID { get; set; }
        public string StudentName { get; set; }
        public bool? IsNewAdmission { get; set; }
        public StuStatus? StuStatus { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? BatchName { get; set; }
        public Branch? Branch { get; set; }
        public string? FatherName { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? StudentMobileNo { get; set; }
        //address
        public string? Address { get; set; }
        public string? AdmissionReference { get; set; }
        public string? BusNumber { get; set; } // New property for Bus Number
        public string? StopName { get; set; } // New property for Stop Name
        public string? RouteName { get; set; } // New property for Route Name
        // This dictionary will hold FeeItemName as key and Tuple of NetAmountDue, AmountPaid as value
        public Dictionary<string, (decimal NetAmountDue, decimal AmountPaid)>? FeeRecords { get; set; }
        // Updated to include FineAmount
        //public Dictionary<string, (decimal NetAmountDue, decimal AmountPaid, decimal FineAmount)> FeeRecords { get; set; }
        // Store FineAmounts separately with FeeRecordId as the key
        public Dictionary<int, decimal>? FineAmounts { get; set; }
        // Add FeeItemNameMapping
        public Dictionary<string, string> FeeItemNameMapping { get; set; }
        public string ClassSection => $"{ClassName} - {SectionName}";

    }

    public class StudentHostelFeeMatrixViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool? IsNewAdmission { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? FatherName { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? Address { get; set; }
        public string? AdmissionReference { get; set; }
        public string? HostelName { get; set; } // New property for Hostel Name
        public string? HostelRoomName { get; set; } // New property for Hostel Room
        /// <summary>
        /// Convenience property to display Class and Section together in grids
        /// </summary>
        public string ClassSection => $"{ClassName} - {SectionName}";
        public Dictionary<string, (decimal NetAmountDue, decimal AmountPaid)> FeeRecords { get; set; }
    }


    public class StudentFeeRecordsViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<FeeRecordDetailViewModel> FeeRecords { get; set; }
        public decimal TotalAmountDue => FeeRecords.Sum(fr => fr.NetAmountDue);
        public decimal TotalAmountPaid => FeeRecords.Sum(fr => fr.AmountPaid);

        public StudentFeeRecordsViewModel()
        {
            FeeRecords = new List<FeeRecordDetailViewModel>();
        }
    }

    public class StudentFeeRecordForFineViewModel
    {
        // Student/context
        public int StudentId { get; set; }
        public string StudentName { get; set; } = "";
        public string AcademicSession { get; set; } = "";
        public string Section_Class { get; set; } = "";

        // FeeRecord core
        public int FeeRecordId { get; set; }
        public int FeeItemId { get; set; }
        public string FeeItemName { get; set; } = "";
        public decimal AmountDue { get; set; }
        public decimal? Discount { get; set; }
        public decimal? AmountPaid { get; set; }

        [NotMapped]
        public decimal AmountPending => AmountDue- (Discount ?? 0m) - (AmountPaid ?? 0m);
        public decimal? PaidUpToCutoff { get; set; }
        public bool ToAddNewAdmission { get; set; }
        public string? DiscountComments { get; set; }
        public string? FeeRecordEditHistory { get; set; }
        public bool IsFineExempt { get; set; }
        public DateTime? EditTime { get; set; }

        // Fine tracking
        public decimal FineDue { get; set; }
        public decimal FinePaid { get; set; }
        public DateTime? FineStartDate { get; set; }
        public DateTime? FineEndDate { get; set; }
    }


    public class FeeRecordDetailViewModel
    {
        public int FeeRecordId { get; set; }
        public string FeeItemName { get; set; }
        public decimal NetAmountDue { get; set; }
        public decimal AmountPaid { get; set; }
    }

    //For Day Receipts Reports
    public class TransferTypeSummaryViewModel
    {
        public string TransferDetails { get; set; }
        public int ReceiptCount { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class MonthlyFeesModel
    {
        public int MonthlyFeesModelId { get; set; }
        public DateTime Date { get; set; }
        public int SchoolID { get; set; }
        [StringLength(255)]
        public string? Comments { get; set; }
        public bool IsOpen { get; set; } // Indicates if fee collection is still open for updates
        public bool IsPosted { get; set; } // Indicates if fees have been finalized and posted
        public int FeeItemId { get; set; }
        //TransferTypeId
        public int? TransferTypeId { get; set; }

        // Audit properties
        public DateTime? PostedTime { get; set; } // Time when fees were posted
        public int? PostedUserId { get; set; } // User who posted the fees
        public string? PosterUserEmail { get; set; } // Email of the user who posted the fees

        // Navigation properties
        public virtual FeeItem FeeItem { get; set; }
        public virtual TransferType? TransferType { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<MonthlyFeesCollection> MonthlyFeesCollections { get; set; }
    }
    public class MonthlyFeesCollection
    {
        public int MonthlyFeesCollectionId { get; set; }
        public int StudentId { get; set; }
        public int MonthlyFeesModelId { get; set; }
        public decimal FeeAmount { get; set; }
        [StringLength(255)]
        public string? Comments { get; set; }

        // Audit properties
        public int? UserId { get; set; } // User who collected the fee
        public string? CollectionUserEmail { get; set; } // Email of the user who collected the fee

        public DateTime? LastEditedTime { get; set; } // Time of the last update

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual MonthlyFeesModel MonthlyFeesModel { get; set; }
    }

    public class MonthlyFeesCollectionViewModel
    {
        public int MonthlyFeesModelId { get; set; }
        public DateTime Date { get; set; }
        public int SchoolID { get; set; }
        public string? Comments { get; set; }
        public bool IsOpen { get; set; }
        public bool IsPosted { get; set; }
        public int FeeItemId { get; set; }
        public string FeeItemName { get; set; }

        public List<StudentFeeViewModel> Fees { get; set; } = new();
    }

    public class StudentFeeViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public decimal FeeAmount { get; set; }
        public string? Comments { get; set; }
    }

    public class MonthlyFeesCollectionSummaryViewModel
    {
        public int? SectionId { get; set; }
        public string ClassSectionName { get; set; }
        public int NumberOfStudentsWithFees { get; set; }
        public decimal TotalFees { get; set; }
    }


    public class DaySummaryViewModel
    {
        public DateTime ReceiptDate { get; set; }
        public decimal TotalReceipts { get; set; }
        public int ReceiptCount { get; set; } // New property for the number of receipts
    }

    public class FeeItemMatrixViewModel
    {
        public DateTime ReceiptDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Dictionary<string, decimal> FeeItemAmounts { get; set; } = new Dictionary<string, decimal>(); // Key: FeeItemName, Value: Amount received
    }
    public class TransferTypeMatrixViewModel
    {
        public DateTime ReceiptDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Dictionary<string, decimal> TransferTypeAmounts { get; set; } = new Dictionary<string, decimal>(); // Key: TransferTypeName, Value: Amount transferred
    }

    public class ReceiptTransferViewModel
    {
        public int OriginalReceiptDetailId { get; set; } // The original receipt detail ID
        public int NewFeeRecordId { get; set; } // The new fee record ID selected
        public decimal TransferAmount { get; set; } // The amount to transfer
    }

    public class FeeFine
    {
        public int FeeFineId { get; set; }
        public int FeeItemId { get; set; }
        [StringLength(255)]
        public string? FeeFineName { get; set; } // New property for the name of the fine
        //AcademicSessionId
        public int? AcademicSessionId { get; set; } // Nullable property for academic session ID
        public string? Description { get; set; } // New property for a description of the fine

        public decimal FineAmountPerDay { get; set; } // Fixed fine amount per day after EffectiveDate
        public DateTime EffectiveDate { get; set; } // The date after which the fine will start accruing
        public DateTime? FineEndDate { get; set; } // The date on which the fine stops accruing (nullable)
        [Range(0, 100, ErrorMessage = "FineAmountTarget must be a percentage between 0 and 100.")]
        public decimal? FineAmountTarget { get; set; } // The target amount until which the fine should be applied
        public bool IsInUse { get; set; } // New property indicating if the fine is active


        // Navigation properties
        public virtual FeeItem? FeeItem { get; set; }
        public virtual AcademicSession? AcademicSession { get; set; } // Nullable property for academic session
        //public virtual School School { get; set; }
    }
    public class ReceiptTotalByTransferTypeViewModel
    {
        public string TransferType { get; set; } // e.g., Cash, Bank Transfer, etc.
        public Dictionary<string, decimal> DayTotals { get; set; } // Key: Date (e.g., "2024-11-12"), Value: Total Amount
    }

    public class DayReceiptTotalByTransferTypeViewModel
    {
        public string TransferType { get; set; } // e.g., Cash, Bank Transfer, etc.
        public decimal TotalAmount { get; set; } // Total amount for the specified day
    }

    public class StudentMessageViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string? StudentMobileNumber { get; set; }
        public decimal TotalPending { get; set; }
        // This string will be a joined message of all FeeItem names and their pending amounts
        public string PendingDetailsMessage { get; set; }
    }

    //ViewModel for DailyReceiptTotalSummary
    public class DailyReceiptTotalSummaryViewModel
    {
        public DateTime Date { get; set; }

        public decimal TotalReceiptAmount { get; set; }
        public string TotalReceiptAmountFormatted => TotalReceiptAmount.ToString("C0", new CultureInfo("en-IN"));
        public int ReceiptCount { get; set; }
    }

    public class FeeBreakupByClassViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        public decimal TotalAmount { get; set; }
        // Aggregated fee amounts by fee item for the class
        public Dictionary<string, decimal> FeeItemAmounts { get; set; } = new Dictionary<string, decimal>();
        public int StudentCount { get; set; }
        // Calculated average fee per student
        public double AverageFee => StudentCount > 0 ? (double)(TotalAmount / StudentCount) : 0;


    }

    public class DueFeeBreakupByClassViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
       
        public decimal NetAmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PendingAmount => NetAmountDue - AmountPaid;
       
        public int StudentCount { get; set; }
        // Calculated average fee per student
        public double AverageFee => StudentCount > 0 ? (double)(NetAmountDue / StudentCount) : 0;

    }

    public class MonthlySummaryReportDto
    {
        public List<DailyReceiptTotalSummaryViewModel> DailySummary { get; set; }
        public List<FeeItemMatrixViewModel> FeeItemSummary { get; set; }
    }
    public class PendingByFeeItemViewModel
    {
        public string FeeItemName { get; set; }
        public decimal PendingAmount { get; set; }
    }
    public class PendingByClassViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        public decimal PendingAmount { get; set; }
    }

    public class PendingFeeItemStackViewModel
    {
        public string FeeItemName { get; set; }
        public Dictionary<string, decimal> ClassPending { get; set; }
            = new Dictionary<string, decimal>(); // Key=ClassName, Value=Pending
    }
    public class PendingClassStackViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        public Dictionary<string, decimal> FeeItemPending { get; set; }
            = new Dictionary<string, decimal>();
    }

    public class PendingFeeReportDto
    {
        public List<PendingByFeeItemViewModel> PendingFeeItemData { get; set; }
        public List<PendingByClassViewModel> PendingClassData { get; set; }
        public List<PendingFeeItemStackViewModel> FeeItemStackData { get; set; }
        public List<PendingClassStackViewModel> ClassStackData { get; set; }
    }

    public class DonutDataPoint
    {
        public string FeeItemName { get; set; }
        public decimal Amount { get; set; }
    }

    public class TransferTypeDataPoint
    {
        public string TransferTypeName { get; set; }
        public decimal Amount { get; set; }
    }


    //Discount Models
    public class DiscountByFeeItemViewModel
    {
        public string FeeItemName { get; set; }
        public decimal DiscountAmount { get; set; }
    }

    public class DiscountByClassViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        public decimal DiscountAmount { get; set; }
    }

    public class DiscountFeeItemStackViewModel
    {
        public string FeeItemName { get; set; }
        // Dictionary with key = ClassName, Value = total discount for that fee item in that class.
        public Dictionary<string, decimal> ClassDiscount { get; set; } = new Dictionary<string, decimal>();
    }

    public class DiscountClassStackViewModel
    {
        public int SchoolClassId { get; set; }
        public string ClassName { get; set; }
        // Dictionary with key = FeeItemName, Value = total discount for that fee item in that class.
        public Dictionary<string, decimal> FeeItemDiscount { get; set; } = new Dictionary<string, decimal>();
    }

public class FeeDiscountReportDto
{
        public List<DiscountByFeeItemViewModel> DiscountByFeeItemData { get; set; }
        public List<DiscountByClassViewModel> DiscountByClassData { get; set; }
        public List<DiscountFeeItemStackViewModel> FeeItemStackDiscountData { get; set; }
        public List<DiscountClassStackViewModel> ClassStackDiscountData { get; set; }

    }


    public class ReceiptCreateTemp
    {
        public int FeeRecordId { get; set; }
        public string FeeItemName { get; set; }
        public string? FeeItemGroupName { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public bool IsPriority { get; set; }
        public int? AcademicSessionId { get; set; }
        public string? AcademicSessionName { get; set; }
        public bool AcademicSessionIsOpen { get; set; }
        // from the DB
        public decimal FeeDue { get; set; }    // e.g. fr.TotalAmount
        public decimal FeePaid { get; set; }    // e.g. fr.AmountPaid
        public decimal FeePending => FeeDue - FeePaid;

        public decimal? FineDue { get; set; }
        public decimal? FinePaid { get; set; }
        public decimal FinePending => (FineDue ?? 0) - (FinePaid ?? 0);
        public int FeeItemOrder { get; set; } // New property for ordering fee items
        // total owed (never includes Amount)
        public decimal TotalPending => FeePending + FinePending;
    }

    public class ClassSectionFeeItemViewModel
    {
        public string ClassSectionName { get; set; }
        // A dictionary of FeeItemName => total amount for that Class–Section.
        public Dictionary<string, decimal> FeeItemAmounts { get; set; } = new Dictionary<string, decimal>();
    }


    public class ReceiptLineDto
    {
        public int ReceiptDetailId { get; set; }
        public int FeeRecordId { get; set; }
        public int FeeItemId { get; set; }
        public string FeeItemName { get; set; } = "";
        public string? ReceiptDetailsComments { get; set; }
        public decimal Amount { get; set; }
        public int ReceiptId { get; set; }
        public short? ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal ReceiptAmount { get; set; }

        public string? TransferType { get; set; } // e.g., Cash, Bank Transfer, etc.


        public string? TransactionId { get; set; }
        public string? Comments { get; set; }
    }









}

    public class SectionPendingFeeRecordSummaryViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
        public decimal TotalFineDue { get; set; }
        public decimal TotalFinePaid { get; set; }
        public decimal TotalFinePending { get; set; }
    }



    public class SectionFeeItemSummaryViewModel
    {
        public int FeeItemId { get; set; }
        public string FeeItemName { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
        public decimal TotalFineDue { get; set; }
        public decimal TotalFinePaid { get; set; }
        public decimal TotalFinePending { get; set; }
    }
