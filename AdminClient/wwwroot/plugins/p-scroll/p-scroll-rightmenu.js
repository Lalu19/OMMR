(function($) {
	"use strict";
	
	//P-scrolling
	const ps2 = new PerfectScrollbar('.sidebar-left', {
	  useBothWheelAxes:false,
	  suppressScrollX:false,
	});
	const ps = new PerfectScrollbar('.first-sidemenu', {
	  useBothWheelAxes:false,
	  suppressScrollX:false,
	});
	const ps1 = new PerfectScrollbar('.second-sidemenu', {
	  useBothWheelAxes:false,
	  suppressScrollX:false,
	});
	
})(jQuery);