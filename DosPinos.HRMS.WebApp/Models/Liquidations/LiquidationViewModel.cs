using DosPinos.HRMS.Entities.DTOs.Liquidation;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Liquidations;

namespace DosPinos.HRMS.WebApp.Models.Liquidations
{
    public class LiquidationViewModel : BaseViewModel
    {
        public LiquidationViewModel()
        {
            this.Title = LiquidationLabel.Title;
            Liquidation = [];
        }

        public List<GetAllLiquidationDTO> Liquidation { get; set; }
    }
}