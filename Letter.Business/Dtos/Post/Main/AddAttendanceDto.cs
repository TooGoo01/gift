namespace Letter.Business.Dtos.Post.Main
{
    public class AddAttendanceDto
    {
        public int? UniversityId { get; set; }
        public int? LetterProgramId { get; set; }
        public int? SpecialityId { get; set; }
        public int? AttendanceTypeId { get; set; }
    }
}
