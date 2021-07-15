using Flunt.Validations;

namespace Domain.ValueObjects
{
    public class IdentificationDocument : ValueObject
    {
        private const int LenghCPF = 11;
        private const int LenghCNPJ = 14;
        public IdentificationDocument(string document)
        {
            Document = document;

            AddNotifications(new Contract<ValueObject>()
                .Requires()
                .IsNotEmpty(Document, "Document", "Document shouldn't be empty"));

            if (!Validate())
                AddNotification("Document", $"Document is invalid.");
        }

        public string Document { get; private set; }

        private bool Validate() 
            => Document.Length == LenghCPF ||
               Document.Length == LenghCNPJ;
    }
}
