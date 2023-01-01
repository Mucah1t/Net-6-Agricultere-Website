using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _TopAddressPartial : ViewComponent 
	{
		private readonly IAdressService _addressService;

		public _TopAddressPartial(IAdressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			var vList = _addressService.GetListAll();
			return View(vList);
		}
	}
}
