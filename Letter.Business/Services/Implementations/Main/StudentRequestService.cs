//using AutoMapper;
//using Letter.Business.Dtos.Get.Main;
//using Letter.Business.Dtos.Post.Main;
//using Letter.Business.Results;
//using Letter.Business.Services.Abstractions.Main;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Letter.DataAccess.UnitOfWorks;
//namespace Letter.Business.Services.Implementations.Main
//{
//    public class StudentRequestService : IStudentRequestService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly IStudentRequestRepository _studentRequestepository;


//        public StudentRequestService(IUnitOfWork unitOfWork, IMapper mapper, IStudentRequestRepository studentRequestepository)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _studentRequestepository = studentRequestepository;
//        }
//        public async Task<ServiceResult> AddStudentRequest(AddStudentRequestDto studentRequest)
//        {
//            var request = _mapper.Map<StudentRequest>(studentRequest);
//            if (studentRequest.CountryIds != null)
//            {
//                request.Countries = (await _unitOfWork.Repository<City>().GetAllAsync(x => studentRequest.CountryIds.Contains(x.Id))).ToList();
//            }
//            if (studentRequest.DirectionIds != null)
//            {
//                request.Directions = (await _unitOfWork.Repository<Direction>().GetAllAsync(x => studentRequest.DirectionIds.Contains(x.Id))).ToList();
//            }
//            request.IsActive = true;
//            await _unitOfWork.Repository<StudentRequest>().AddAsync(request);
//            _unitOfWork.Commit();
//            return new ServiceResult(true);
//        }

//        public async Task<ServiceResult> DeleteRequestById(int requestId)
//        {
//            var request = await _studentRequestepository.GetStudentRequest(requestId);

//            if (request == null)
//                return new ServiceResult(false, "Contact not found");
//            request.IsActive = false;
//            _unitOfWork.Repository<StudentRequest>().Update(request);
//            _unitOfWork.Commit();
//            return new ServiceResult(true);
//        }

//        public async Task<ServiceResult> GetRequests()
//        {
//            var req = await _studentRequestepository.GetAllStudentRequests();

//            if (req == null)
//                return new ServiceResult(false);

//            var response = _mapper.Map<List<GetStudentRequestDto>>(req);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetRequest(int id)
//        {
//            var req = await _studentRequestepository.GetStudentRequest(id);

//            if (req == null)
//                return new ServiceResult(false);
//            var response = _mapper.Map<GetStudentRequestDto>(req);
//            return new ServiceResult(true, response);
//        }
//        public async Task<ServiceResult> GetLastStudentRequest()
//        {
//            var req = await _studentRequestepository.GetLastStudentRequest();

//            if (req == null)
//                return new ServiceResult(false);
//            var response = _mapper.Map<GetStudentRequestDto>(req);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetActiveRequests()
//        {
//            var req = await _studentRequestepository.GetActiveStudentRequests();

//            if (req == null)
//                return new ServiceResult(false);

//            var response = _mapper.Map<List<GetStudentRequestDto>>(req);
//            return new ServiceResult(true, response);

//        }

//        public async Task<ServiceResult> GetNonSeenStudentRequests()
//        {
//            var req = await _studentRequestepository.GetNonSeenStudentRequests();

//            if (req == null)
//                return new ServiceResult(false);

//            var response = _mapper.Map<List<GetStudentRequestDto>>(req);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetSeenStudentRequests()
//        {
//            var req = await _studentRequestepository.GetSeenStudentRequests();

//            if (req == null)
//                return new ServiceResult(false);

//            var response = _mapper.Map<List<GetStudentRequestDto>>(req);
//            return new ServiceResult(true, response);
//        }


//        public async Task<ServiceResult> MakeSeenRequest(int id)
//        {
//            var studentRequest = await _studentRequestepository.GetStudentRequest(id);

//            if (studentRequest == null)
//                return new ServiceResult(false);

//            studentRequest.Seen = true;
//            _unitOfWork.Repository<StudentRequest>().Update(studentRequest);
//            _unitOfWork.Commit();
//            var response = _mapper.Map<GetStudentRequestDto>(studentRequest);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> ExportToExcel()
//        {
//            var studentRequests = await _studentRequestepository.GetActiveStudentRequests();
//            var data = _mapper.Map<ICollection<GetStudentRequestDto>>(studentRequests);

//            // Create a new Excel package
//            using (var package = new ExcelPackage())
//            {
//                // Create a new worksheet
//                var worksheet = package.Workbook.Worksheets.Add("StudentRequests");

//                // Set the headers
//                worksheet.Cells[1, 1].Value = "Id";
//                worksheet.Cells[1, 2].Value = "Name";
//                worksheet.Cells[1, 3].Value = "SurName";
//                worksheet.Cells[1, 4].Value = "Phone";
//                worksheet.Cells[1, 5].Value = "WhatsAppPhone";
//                worksheet.Cells[1, 6].Value = "Email";
//                worksheet.Cells[1, 7].Value = "Description";
//                worksheet.Cells[1, 8].Value = "ConsultationDate";
//                worksheet.Cells[1, 9].Value = "IsOnline";
//                worksheet.Cells[1, 10].Value = "IsActive";
//                worksheet.Cells[1, 11].Value = "YourCountry";
//                worksheet.Cells[1, 11].Value = "Countries";
//                worksheet.Cells[1, 11].Value = "Directions";

//                // Set the column widths
//                worksheet.Column(1).AutoFit();
//                worksheet.Column(2).AutoFit();
//                worksheet.Column(3).AutoFit();
//                worksheet.Column(4).AutoFit();
//                worksheet.Column(5).AutoFit();
//                worksheet.Column(6).AutoFit();
//                worksheet.Column(7).AutoFit();
//                worksheet.Column(8).AutoFit();
//                worksheet.Column(9).AutoFit();
//                worksheet.Column(10).AutoFit();
//                worksheet.Column(11).AutoFit();
//                worksheet.Column(12).AutoFit();
//                worksheet.Column(13).AutoFit();

//                // Populate the data
//                var row = 2;
//                foreach (var student in data)
//                {
//                    worksheet.Cells[row, 1].Value = student.Id;
//                    worksheet.Cells[row, 2].Value = student.Name;
//                    worksheet.Cells[row, 3].Value = student.SurName;
//                    worksheet.Cells[row, 4].Value = student.Phone;
//                    worksheet.Cells[row, 5].Value = student.WhatsAppPhone;
//                    worksheet.Cells[row, 6].Value = student.Email;
//                    worksheet.Cells[row, 7].Value = student.Description;
//                    worksheet.Cells[row, 8].Value = student.ConsultationDate;
//                    worksheet.Cells[row, 9].Value = student.IsOnline;
//                    worksheet.Cells[row, 10].Value = student.IsActive;
//                    worksheet.Cells[row, 11].Value = student.YourCountry;
//                    worksheet.Cells[row, 12].Value = string.Join(",", student.Countries.Select(c => c.Id));
//                    worksheet.Cells[row, 13].Value = string.Join(",", student.Directions.Select(d => d.Id));
//                    row++;
//                }


//                var filePath = Path.Combine("wwwroot/resurce");
//                if (!Directory.Exists(filePath))
//                {
//                    Directory.CreateDirectory(filePath);
//                }
//                string fullpath = Path.Combine(filePath, "StudentRequests.xlsx");
//                System.IO.File.WriteAllBytes(fullpath, package.GetAsByteArray());

//                // Return the file path to the client
//                return new ServiceResult(true, $"{fullpath.Remove(0, 8)}");

//            }
//            return new ServiceResult(false);
//        }
//    }
//}
