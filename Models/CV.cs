namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje dokument CV przesłany przez użytkownika.
    /// </summary>
    public class CV
    {
        /// <summary>
        /// Unikalny identyfikator CV.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identyfikator użytkownika, do którego należy CV.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Ścieżka do pliku CV na serwerze lub w magazynie plików.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Data i godzina przesłania CV. Domyślnie ustawiona na bieżący czas.
        /// </summary>
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Zgoda użytkownika na przetwarzanie danych osobowych.
        /// </summary>
        public bool UserConsent { get; set; }

        /// <summary>
        /// Status przechowywania CV (np. "Active", "Expired", "Deleted").
        /// </summary>
        public string RetentionStatus { get; set; }

        /// <summary>
        /// Obiekt użytkownika, który przesłał CV.
        /// </summary>
        public virtual User User { get; set; }
    }
}