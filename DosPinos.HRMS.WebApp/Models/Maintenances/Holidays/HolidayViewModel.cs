using DosPinos.HRMS.Entities.DTOs.Holidays;
using DosPinos.HRMS.Entities.DTOs.WorkingDays.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Maintenances;

namespace DosPinos.HRMS.WebApp.Models.Maintenances.Holidays
{
    public class HolidayViewModel : BaseViewModel
    {
        public HolidayViewModel()
        {
            Title = MaintenanceLabel.HolidayTitle;
            HolidayObj = new();
            UpdateHolidayObj = new();
            Holidays = [];
        }

        public CreateHolidayDTO HolidayObj { get; set; }
        public UpdateHolidayDTO UpdateHolidayObj { get; set; }
        public List<GetAllHolidayDTO> Holidays { get; set; }
    }
}