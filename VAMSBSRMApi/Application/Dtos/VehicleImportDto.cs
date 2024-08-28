namespace VAMSBSRMApi.Application.Dtos
{
    public class VehicleImportDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
