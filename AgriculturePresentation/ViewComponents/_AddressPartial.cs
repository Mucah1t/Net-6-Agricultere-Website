using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _AddressPartial:ViewComponent
	{
		private readonly IAdressService _addressService;

		public _AddressPartial(IAdressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()
		{
			var vList= _addressService.GetListAll();
			return View(vList);
		}
	}
}
