namespace DEU_Lib.Model
{
    public interface IFile
    {
        int FileId { get; set; }
        /// <summary>
        /// The name of the file
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The path of the file
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// The type of the file, e.g. image/png
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// The size of the file
        /// </summary>
        long Size { get; set; }
        /// <summary>
        /// Change date of the file
        /// </summary>
        DateTime ChangeDate { get; set; }

        /// <summary>
        /// The OperationActionId for the OperationAction that the file is part of
        /// </summary>
        Guid? OperationActionId { get; set; }
        /// <summary>
        /// The OperationAction that the file is part of
        /// </summary>
        OperationAction? OperationAction { get; set; }

        /// <summary>
        /// The PoiId for the Poi that the file is part of
        /// </summary>
        Guid? PoiId { get; set; }
        /// <summary>
        /// The Poi that the file is part of
        /// </summary>
        Poi? Poi { get; set; }
    }

    public class File : IFile
    {
        public int FileId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public long Size { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
        public Guid? OperationActionId { get; set; }
        public OperationAction? OperationAction { get; set; }
        public Guid? PoiId { get; set; }
        public Poi? Poi { get; set; }
    }
}