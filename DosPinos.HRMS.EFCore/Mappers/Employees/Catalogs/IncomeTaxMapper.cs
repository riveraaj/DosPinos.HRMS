namespace DosPinos.HRMS.EFCore.Mappers.Employees.Catalogs
{
    internal static class IncomeTaxMapper
    {
        public static IGetAllIncomeTaxDTO MapFrom(IncomeTax incomeTax)
           => new GetAllIncomeTaxDTO()
           {
               IncomeTaxId = incomeTax.IncomeTaxId,
               IncomeTaxPercentage = incomeTax.IncomeTaxPercentage,
           };
    }
}