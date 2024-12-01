using DosPinos.HRMS.Entities.DTOs.ChristmasBonus;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.ChristmasBonus;

namespace DosPinos.HRMS.WebApp.Models.ChristmasBonus
{
    public class ChristmasBonusViewModel : BaseViewModel
    {
        public ChristmasBonusViewModel()
        {
            this.Title = ChristmasBonusLabel.Title;
            ChristmasBonus = [];
        }
        public List<GetAllChristmasBonusDTO> ChristmasBonus { get; set; }
    }
}