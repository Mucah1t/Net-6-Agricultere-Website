﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.ViewComponents
{
	public class _TeamPartial:ViewComponent
	{
		private readonly ITeamService _teamService;

		public _TeamPartial(ITeamService teamService)
		{
			_teamService = teamService;
		}

		public IViewComponentResult Invoke()
		{
			var vList = _teamService.GetListAll();
			return View(vList);
		}
	}
}
