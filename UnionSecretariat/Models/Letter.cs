namespace UnionSecretariat.Models
{
    public class Letter
    {
        public int Id { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime LetterDate { get; set; }
        public int SectionLkpId { get; set; }
        public int SecretariatLkpId { get; set; }
        public int ArrangementLkpId { get; set; }
        public int LetterPriorityLkpId { get; set; }
        public string LetterCopy { get; set; }
        public int ForeignRecieverLkpId { get; set; }
        public int RecieverLkpId { get; set; }
        public int LetterRecieveKindLkpId { get; set; }
        public int PostCompanyLkpId { get; set; }
        public int PostKindLkpId { get; set; }
        public string LetterNumber { get; set; }
        public int AndikatorNumber { get; set; }
        public string ReturnToNumber { get; set; }
        public int AttachmentCount { get; set; }
        public string AttachmentTypeLkpIds { get; set; }
        public string Sender { get; set; }
        public string SecondReciever { get; set; }
        public DateTime? BoxDateTimePicker { get; set; }
        public string PostBarcode { get; set; }
        public DateTime? RecieveDateTimePicker { get; set; }
        public string LetterSubject { get; set; }
        public string MainText { get; set; }
        public int MainLetterId { get; set; }
        public string LetterDescription { get; set; }
        public int GuildId { get; set; }

        public List<LettersImages> LettersImageses { get; set; }
    }

    public class LettersImages
    {
        public int Id { get; set; }
        public int objectID { get; set; }
        public int OpTypes { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public byte[] Image4 { get; set; }
        public byte[] Image5 { get; set; }
        public byte[] Image6 { get; set; }
        public byte[] Image7 { get; set; }
        public byte[] Image8 { get; set; }
        public byte[] Image9 { get; set; }
        public byte[] Image10 { get; set; }
        public byte[] Image11 { get; set; }
        public byte[] Image12 { get; set; }
        public byte[] Image13 { get; set; }
        public byte[] Image14 { get; set; }
        public byte[] Image15 { get; set; }
        public int LetterId { get; set; }
        
    }
}
