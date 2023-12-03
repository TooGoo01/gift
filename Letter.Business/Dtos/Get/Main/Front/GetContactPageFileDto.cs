namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetContactPageFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public byte[] Bytes { get; set; }
    }
}
