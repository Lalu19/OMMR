(function($) {
	"use strict";
	

	/*PMboYSIqMee+p4uAjskftSrErYaF9PDNDn+EGSzR9N2BspYI8=
feCz66HNQhyoUIndT6pXQpWta+PA3e1h3yExMyH1EsOo6f8PXnNPyHGLRfchOSF9WSX7exs=*/
	// ______________Full screen
	$("#fullscreen-button").on("click", function toggleFullScreen() {
		if ((document.fullScreenElement !== undefined && document.fullScreenElement === null) || (document.msFullscreenElement !== undefined && document.msFullscreenElement === null) || (document.mozFullScreen !== undefined && !document.mozFullScreen) || (document.webkitIsFullScreen !== undefined && !document.webkitIsFullScreen)) {
			if (document.documentElement.requestFullScreen) {
				document.documentElement.requestFullScreen();
			} else if (document.documentElement.mozRequestFullScreen) {
				document.documentElement.mozRequestFullScreen();
			} else if (document.documentElement.webkitRequestFullScreen) {
				document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
			} else if (document.documentElement.msRequestFullscreen) {
				document.documentElement.msRequestFullscreen();
			}
		} else {
			if (document.cancelFullScreen) {
				document.cancelFullScreen();
			} else if (document.mozCancelFullScreen) {
				document.mozCancelFullScreen();
			} else if (document.webkitCancelFullScreen) {
				document.webkitCancelFullScreen();
			} else if (document.msExitFullscreen) {
				document.msExitFullscreen();
			}
		}
	})
	
	// ______________ PAGE LOADING
	$(window).on("load", function(e) {
		$("#global-loader").fadeOut("slow");
	})
	
	// ______________ BACK TO TOP BUTTON
	$(window).on("scroll", function(e) {
		if ($(this).scrollTop() > 0) {
			$('#back-to-top').fadeIn('slow');
		} else {
			$('#back-to-top').fadeOut('slow');
		}
	});
	$("#back-to-top").on("click", function(e) {
		$("html, body").animate({
			scrollTop: 0
		}, 600);
		return false;
	});
	
	// ______________ COVER IMAGE
	$(".cover-image").each(function() {
		var attr = $(this).attr('data-image-src');
		if (typeof attr !== typeof undefined && attr !== false) {
			$(this).css('background', 'url(' + attr + ') center center');
		}
	});
	
	// ______________ RATING STAR
	var ratingOptions = {
		selectors: {
			starsSelector: '.rating-stars',
			starSelector: '.rating-star',
			starActiveClass: 'is--active',
			starHoverClass: 'is--hover',
			starNoHoverClass: 'is--no-hover',
			targetFormElementSelector: '.rating-value'
		}
	};
	$(".rating-stars").ratingStars(ratingOptions);
	
	
	// ______________Chart-circle
	if ($('.chart-circle').length) {
		$('.chart-circle').each(function() {
			let $this = $(this);
			$this.circleProgress({
				fill: {
					color: $this.attr('data-color')
				},
				size: $this.height(),
				startAngle: -Math.PI / 4 * 2,
				emptyFill: '#f6f6f6',
				lineCap: 'round'
			});
		});
	}
	
	// ______________ GLOBAL SEARCH
	$(document).on("click", "[data-toggle='search']", function(e) {
		var body = $("body");

		if(body.hasClass('search-gone')) {
			body.addClass('search-gone');
			body.removeClass('search-show');
		}else{
			body.removeClass('search-gone');
			body.addClass('search-show');
		}
	});
	var toggleSidebar = function() {
		var w = $(window);
		if(w.outerWidth() <= 1024) {
			$("body").addClass("sidebar-gone");
			$(document).off("click", "body").on("click", "body", function(e) {
				if($(e.target).hasClass('sidebar-show') || $(e.target).hasClass('search-show')) {
					$("body").removeClass("sidebar-show");
					$("body").addClass("sidebar-gone");
					$("body").removeClass("search-show");
				}
			});
		}else{
			$("body").removeClass("sidebar-gone");
		}
	}
	toggleSidebar();
	$(window).resize(toggleSidebar);
	
	/** Constant div card */
	const DIV_CARD = 'div.card';
	/** Initialize tooltips */
	$('[data-toggle="tooltip"]').tooltip();
	/** Initialize popovers */
	$('[data-toggle="popover"]').popover({
		html: true
	});
	
	// ______________ FUNCTION FOR REMOVE CARD
	$('[data-toggle="card-remove"]').on('click', function(e) {
		let $card = $(this).closest(DIV_CARD);
		$card.remove();
		e.preventDefault();
		return false;
	});
	
	// ______________ FUNCTIONS FOR COLLAPSED CARD
	$('[data-toggle="card-collapse"]').on('click', function(e) {
		let $card = $(this).closest(DIV_CARD);
		$card.toggleClass('card-collapsed');
		e.preventDefault();
		return false;
	});
	/*PMboYSIqMee+p4uAjskftSrErYaF9PDNDn+EGSzR9N2BspYI8=
feCz66HNQhyoUIndT6pXQpWta+PA3e1h3yExMyH1EsOo6f8PXnNPyHGLRfchOSF9WSX7exs=*/
	// ______________ CARD FULL SCREEN
	$('[data-toggle="card-fullscreen"]').on('click', function(e) {
		let $card = $(this).closest(DIV_CARD);
		$card.toggleClass('card-fullscreen').removeClass('card-collapsed');
		e.preventDefault();
		return false;
	});
	
	
	// ______________Skins
	
	/*//////////////////// Header skins  //////////////////////*/
	
	//$('body').addClass("default-header"); // 
	
	// $('body').addClass("color-header"); //
	
	// $('body').addClass("dark-header"); //
	
	/*//////////////////// Horizontal skins  //////////////////////*/
	
	//$('body').addClass("default-hor");  //
	
	// $('body').addClass("light-hor"); //
	
	// $('body').addClass("dark-hor"); //
	
	/*//////////////////// Left-menu skins  //////////////////////*/
	
	//$('body').addClass("default-left"); // 
	
	//$('body').addClass("light-left"); // 
	
	//$('body').addClass("dark-left"); // 
	
	//$('body').addClass("menu-style1"); // 
	
})(jQuery);
