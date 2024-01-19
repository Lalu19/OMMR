(function($) {
	"use strict";
	
	//Active Class
	$(".app-sidebar a").each(function() {
		var pageUrl = window.location.href.split(/[?#]/)[0];
		if (this.href == pageUrl) {
			$(this).addClass("active");
			$(this).parent().parent().parent().parent().parent().parent().parent().addClass("active"); // add active to li of the current link
			$(this).parent().parent().parent().parent().parent().parent().parent().addClass("resp-tab-content-active"); // add active to li of the current link
			$(this).parent().parent().parent().parent().parent().prev().addClass("active"); // add active class to an anchor
			$(this).parent().parent().prev().click(); // click the item to make it drop
		}
	});
	
	$(".side-menu a").each(function() {
		var pageUrl = window.location.href.split(/[?#]/)[0];
		if (this.href == pageUrl) {
			$(this).addClass("active");
			$(this).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().addClass("active"); // add active to li of the current link
			$(this).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().addClass("resp-tab-content-active"); // add active to li of the current link
			$(this).parent().parent().parent().parent().parent().prev().addClass("active"); // add active class to an anchor
			$(this).parent().parent().prev().click(); // click the item to make it drop
		}
	});
	
	$(document).ready(function(){		
			
		if ($('.element-slica.active').hasClass('active'))
        $('li.element-slica').addClass('active');
	
		if ($('.pages-slica.active').hasClass('active'))
        $('li.pages-slica').addClass('active');
	
		if ($('.dashboard-slica.active').hasClass('active'))
        $('li.dashboard-slica').addClass('active');
	
		if ($('.widget-slica.active').hasClass('active'))
        $('li.widget-slica').addClass('active');
		
		if ($('.components-slica.active').hasClass('active'))
        $('li.components-slica').addClass('active');
	
		if ($('.icons-slica.active').hasClass('active'))
        $('li.icons-slica').addClass('active');
	
		if ($('.forms-slica.active').hasClass('active'))
        $('li.forms-slica').addClass('active');
	
		if ($('.charts-slica.active').hasClass('active'))
        $('li.charts-slica').addClass('active');
	
		if ($('.ecommerce-slica.active').hasClass('active'))
        $('li.ecommerce-slica').addClass('active');
		
		if ($('.custom-slica.active').hasClass('active'))
        $('li.custom-slica').addClass('active');
	
	
	});
	
	
	// VerticalTab
	$('#sidemenu-Tab').easyResponsiveTabs({
		type: 'vertical',
		width: 'auto', 
		fit: true, 
		closed: 'accordion',
		tabidentify: 'hor_1',
		activate: function(event) {
			var $tab = $(this);
			var $info = $('#nested-tabInfo2');
			var $name = $('span', $info);
			$name.text($tab.text());
			$info.show();
		}
	});
	
	
})(jQuery);