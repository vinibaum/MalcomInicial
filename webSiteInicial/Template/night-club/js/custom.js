/*
Copyright (c) 2016 NightClub
------------------------------------------------------------------
[Master Javascript]

Project: NightClub

-------------------------------------------------------------------*/
(function($) {
	"use strict";
	var nightclub = {
		initialised: false,
		version: 1.0,
		mobile: false,
		init: function() {
			if (!this.initialised) {
				this.initialised = true;
			} else {
				return;
			}
			/*-------------- nightclub Functions Calling ---------------------------------------------------
			------------------------------------------------------------------------------------------------*/
			this.RTL();
			this.slider();
			this.navigation_menu();
			this.Eventcrousel();
			this.trackcrousel();
			this.video_popup();
			this.clubcrousel();
			this.video_crousel();
			this.testimonial_slider();
			this.gallery();
			this.mediaelement();
			this.datetimepicker();
			this.activeclass();
			this.booking_table();
			this.MailFunction();
			this.Greensock_animation();
		},
		/*-------------- nightclub Functions definition ---------------------------------------------------
		---------------------------------------------------------------------------------------------------*/
		RTL: function() {
			// On Right-to-left(RTL) add class 
			var rtl_attr = $("html").attr('dir');
			if (rtl_attr) {
				$('html').find('body').addClass("rtl");
			}
		},
		slider: function() {
			//slider script
			var tpj = jQuery;
			var revapi4;
			if (tpj("#rev_slider_4_1").revolution == undefined) {
				revslider_showDoubleJqueryError("#rev_slider_4_1");
			} else {
				revapi4 = tpj("#rev_slider_4_1").show().revolution({
					sliderType: "standard",
					jsFileLocation: "../../revolution/js/",
					sliderLayout: "fullscreen",
					dottedOverlay: "none",
					delay: 8000,
					navigation: {
						keyboardNavigation: "off",
						keyboard_direction: "horizontal",
						mouseScrollNavigation: "off",
						onHoverStop: "off",
						touch: {
							touchenabled: "on",
							swipe_threshold: 75,
							swipe_min_touches: 1,
							swipe_direction: "horizontal",
							drag_block_vertical: false
						},
						arrows: {
							style: "zeus",
							enable: true,
							hide_onmobile: true,
							hide_under: 1300,
							hide_onleave: true,
							hide_delay: 200,
							hide_delay_mobile: 1200,
							tmp: '<div class="tp-title-wrap">  	<div class="tp-arr-imgholder"></div> </div>',
							left: {
								h_align: "left",
								v_align: "center",
								h_offset: 30,
								v_offset: 0
							},
							right: {
								h_align: "right",
								v_align: "center",
								h_offset: 30,
								v_offset: 0
							}
						}
					},
					viewPort: {
						enable: true,
						outof: "pause",
						visible_area: "80%"
					},
					gridwidth: 1240,
					gridheight: 550,
					lazyType: "none",
					parallax: {
						type: "mouse",
						origo: "slidercenter",
						speed: 2000,
						levels: [2, 3, 4, 5, 6, 7, 12, 16, 10, 50],
					},
					shadow: 0,
					spinner: "off",
					stopLoop: "off",
					stopAfterLoops: -1,
					stopAtSlide: -1,
					shuffle: "off",
					autoHeight: "off",
					hideThumbsOnMobile: "off",
					hideSliderAtLimit: 0,
					hideCaptionAtLimit: 0,
					hideAllCaptionAtLilmit: 0,
					debugMode: false,
					fallbacks: {
						simplifyAll: "off",
						nextSlideOnWindowFocus: "off",
						disableFocusListener: false,
					}
				});
			}
		},
		navigation_menu: function() {
			//add dropdown icon in menu
			$(".nc_navigations ul.sub-menu").parents("li").addClass("dropdown_menu");
			$(".nc_navigations ul.sub-menu").parents("li.dropdown_menu").prepend('<i class="caret_down"></i>');
		    //navigation menu fixed on scroll
			var slider_h = $('.nc_header_main_home1').innerHeight() - 99;
			//alert(slider_h);
			$(window).on('bind scroll', function(e) {
				if ($(window).scrollTop() > slider_h && $(window).width() > 991) {
					$('.wrapper_navigation').addClass('fixed_top_menu');
				}
				else {
					$('.wrapper_navigation').removeClass('fixed_top_menu');
				}
			});
			//mobile toggle menu
			$('.navbar_toggle').on('click', function(){
				$(this).toggleClass('toggle_open');
				$('.nc_navigations').toggleClass('menu_open');
			});
		    //mobile toggle submenu
			$('.nc_navigations > ul > li.dropdown_menu').on('click', function(e) {
				if ($(window).width() < 991) {
					$('.nc_navigations > ul > li > ul.sub-menu');
					$(this).find("ul").toggle(500);
				} 
				else {
					
				}
			});
			
		
		},
		
		//eventcrousel
		Eventcrousel: function() {
			$(".event_crousel").owlCarousel({
				mode: 'fade',
				autoplay: true,
				margin: 20,
				items: 2,
				touchDrag: true,
				responsiveClass: true,
				animateIn: true,
				animateOut: true,
				responsive: {
					0: {
						items: 1
					},
					480: {
						items: 1
					},
					600: {
						items: 1
					},
					1000: {
						items: 2
					}
				},
				paginationSpeed: 1000,
				slideSpeed: 500,
				smartSpeed: 250
			});
		},
		trackcrousel: function() {
			$(".track_crousel").owlCarousel({
				autoplay: false,
				margin: 0,
				items: 5,
				responsiveClass: true,
				dots: false,
				nav: true,
				navText: ['<i class="fa fa-caret-left"></i>', '<i class="fa fa-caret-right"></i>'],
				animateIn: true,
				animateOut: true,
				responsive: {
					0: {
						items: 1
					},
					480: {
						items: 2
					},
					600: {
						items: 3
					},
					1000: {
						items: 5
					}
				}
			});
		},
		//home video popup
		video_popup: function () {
			//autoplay video
			$('.video_overlay > a').click(function(){
				setTimeout(function(){
					$('#video_1 .mejs-overlay-play').trigger("click");
				},200);
			});
			
			$('.video_popup').magnificPopup({
				type: 'inline',
				removalDelay: 300,
				mainClass: 'my_zoom_in',
				removalDelay: 160,
				preloader: false,
				fixedContentPos: false,
			});
		},
		//clubcrousel
		clubcrousel: function() {
			$(".club_crousel").owlCarousel({
				autoplay: true,
				margin: 30,
				items: 3,
				responsiveClass: true,
				responsive: {
					0: {
						items: 1
					},
					480: {
						items: 1
					},
					600: {
						items: 2
					},
					1000: {
						items: 3
					}
				}
			});
		},
		//video crousel 
		video_crousel: function() {
			$(".video_crousel").owlCarousel({
				autoplay: false,
				margin: 0,
				items: 1,
				singleItems: true,
				responsiveClass: true,
				dots: false,
				nav: true,
				navText: ['<i class="fa fa-caret-left"></i>', '<i class="fa fa-caret-right"></i>']
			});
		},
		//owl slider
		testimonial_slider: function() {
			//testimonialslider
			$(".testimonial_crousel").owlCarousel({
				loop:true,
				margin: 0,
				autoplay: true,
				items: 1,
				singleItems: true,
				touchDrag: true,
				responsiveClass: true
			});
		},
		
		//gallery 
		gallery: function() {
			//sidebar gallery
			$('.sidebar_gallery').magnificPopup({
				delegate: 'a',
				type: 'image',
				tLoading: 'Loading image #%curr%...',
				removalDelay: 300,
				mainClass: 'image_fade',
				gallery: {
					enabled: true,
					navigateByImgClick: true,
					preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
				},
				image: {
					tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
					titleSrc: function(item) {
						return item.el.attr('title') + '<small></small>';
					}
				}
			});
			//photo gallery
			$('.photo_gallery_popup').magnificPopup({
				type: 'inline',
				fixedContentPos: false,
				fixedBgPos: true,
				overflowY: 'auto',
				midClick: true,
				gallery: {
					enabled: true,
					navigateByImgClick: true,
					preload: [0, 1]
				},
				removalDelay: 300,
				mainClass: 'my_zoom_in'
			});
			//video gallery
			$('.video_popup_gallery').magnificPopup({
				type: 'inline',
				removalDelay: 300,
				mainClass: 'my_zoom_in',
				removalDelay: 160,
				preloader: false,
				fixedContentPos: false,
			});
		},
		//mediaelement
		mediaelement: function() {
			//audio media
			$('audio').mediaelementplayer({
				loop: true,
				autoplay: true,
				playlist: true,
				favourite: true,
				audioHeight: 30,
				playlistposition: 'bottom',
				features: ['playlistfeature', 'prevtrack', 'playpause', 'nexttrack', 'shuffle', 'tracks', 'current', 'duration', 'progress', 'volume']
			});
			//video media
			$('video').mediaelementplayer({
				loop: true,
				autoplay: true,
				playlist: false,
				audioHeight: 50,
				playlistposition: 'bottom',
				videoVolume: 'horizontal',
				features: ['playlistfeature', 'playpause', 'loop', 'current', 'duration', 'progress', 'volume']
			});
			//audio playlist
			$('.media_player .mejs-nexttrack').attr('data-current','audio_2');
			$('.media_player .mejs-prevtrack').attr('data-current','audio_7'); // last audio track ID
			
			//audio playlist
			$('.play_button .fa-play').click(function(){
				$('.mejs-mediaelement #mejs').prop('src',$(this).attr('data-audio'));
				var audio_title = $(this).attr("data-title"); // value of the audio title
				var track_thumb = $(this).parent().parent().prev('img').attr('src'); // value of the thumb src
				$('.mejs-mediaelement #mejs').html('<source src="'+$(this).prop('data-audio')+'" title="'+audio_title+'" type="audio/mp3">');
				$('.track_crousel .item').removeClass('active');
				$(this).parent().parent().parent('.item').addClass('active');
				
				$('.media_player .mejs-playlist .mejs > li').text(audio_title); // change audio title
				$('.nc_media_player > .track_thumb > img').attr('src',track_thumb);  // change thumb image of the track
				setTimeout(function(){
					$('.media_player .mejs-playpause-button').trigger('click'); // play track on click
				},300);
				
				$('.media_player .mejs-nexttrack').attr('data-current',$(this).attr('id'));
				$('.media_player .mejs-prevtrack').attr('data-current',$(this).attr('id'));
			});
			
			// audio next/prev track
			$('.media_player .mejs-nexttrack').on('click', function(){
				var curId = $(this).attr('data-current');
				var nextId = $('#'+curId).attr('data-next');
				$('#'+nextId).trigger('click');
			});
			
			// audio next/prev track
			$('.media_player .mejs-prevtrack').on('click', function(){
				var curId = $(this).attr('data-current');
				var prevId = $('#'+curId).attr('data-prev');
				$('#'+prevId).trigger('click');
			});
			
		},
		//datepicker
		datetimepicker: function() {
			$(".datepicker").datepicker({
				showOn: "button",
				dateFormat: "dd/mm/yy"
			});
		},
		
		activeclass: function() {
			//pagination active 
			$(".pagination a").on("click", function() {
				$(".pagination").find(".active").removeClass("active");
				$(this).parent().addClass("active");
			});
			//active class club slider
			$(".carousel-inner .item:first-child").addClass("active");
		},
		booking_table: function() {
			//js for booking_table
			$(".book_thumb").on("click", function() {
				$(".book_thumb").find(".seat_active").removeClass("seat_active");
				$(this).parent().addClass("seat_active");
				$(this).children('.table_overlay').css('cursor', 'not-allowed');
				$(this).children('.table_overlay').children('.reserved_tbl').html('Reserve');
			});
			//table close
			$(".nc_table_close").on("click", function() {
				$(".book_thumb").find(".seat_active");
				$(this).parent().removeClass("seat_active");
				$('.table_overlay').css('cursor', 'pointer');
			});
		},
        MailFunction:function(){
			//contact form mail function
			//contact mail function	
			$('#submit_frm').on('click', function(){
				var un=$('#uname').val();
				var em=$('#uemail').val();
				var wsite=$('#web_site').val();
				var meesg=$('#message').val();
				
				$.ajax({
					type: "POST",
					url: "ajaxmail.php",
					data: {
						'username':un,
						'useremail':em,
						'website':wsite,
						'mesg':meesg,
						},
					success: function(msg) {
						var full_msg=msg.split("#");
						if(full_msg[0]=='1'){
							$('#uname').val("");
							$('#uemail').val("");
							$('#web_site').val("");
							$('#message').val("");
							$('#err').html( full_msg[1] );
						}
						else{
							$('#uname').val(un);
							$('#uemail').val(em);
							$('#web_site').val(wsite);
							$('#message').val(meesg);
							$('#err').html( full_msg[1] );
						}
					}
				});
			});
			
			//table booking mail function 
			$('#booking_table').on('click', function(){
				var book_fname=$('#booking_fname').val();
				var book_mail=$('#booking_mail').val();
				var book_tn=$('#booking_table_no').val();
				var book_guest=$('#booking_guest').val();
				var book_date=$('#booking_date').val();
				var book_phone=$('#booking_phone').val();
				var book_instruction=$('#booking_instruction').val();
				
				$.ajax({
					type: "POST",
					url: "book_table.php",
					data: {
						'booking_fname':book_fname,
						'booking_mail':book_mail,
						'booking_table_no':book_tn,
						'booking_guest':book_guest,
						'booking_date':book_date,
						'booking_phone':book_phone,
						'booking_instruction':book_instruction,
					},
					success: function(msg) {
						var full_msg=msg.split("#");
						if(full_msg[0]=='1')
						{   $('#booking_fname').val("");
					        $('#booking_mail').val("");
							$('#booking_table_no').val("");
							$('#booking_guest').val("");
							$('#booking_date').val("");
							$('#booking_phone').val("");
							$('#booking_instruction').val("");
							$('#booking_err').html( full_msg[1] );
						}
						else
						{   $('#booking_fname').val(book_fname);
					        $('#booking_mail').val(book_mail);
							$('#booking_table_no').val(book_tn);
							$('#booking_guest').val(book_guest);
							$('#booking_date').val(book_date);
							$('#booking_phone').val(book_phone);
							$('#booking_instruction').val(book_instruction);
							$('#booking_err').html( full_msg[1] );
						}
					}
				});
			});
		
		},
 		
		Greensock_animation: function() {
			// animation js start on page load
			// logo animation
			TweenMax.from(".nc_logo", 2, {
				scale: 0.2, opacity: 0, ease: Power3.easeInOut
			});
			TweenMax.to(".nc_logo", 2, {
				scale: 1, opacity: 1, ease: Power3.easeInOut
			});
			
			//contact us page
			TweenMax.to(".event_page_main .nc_event_cover", 2, {
				x: 0, opacity: 1, delay: 0.5, ease: Power3.easeInOut
			});
			TweenMax.to(".event_page_main .nc_event_cover", 2, {
				x: 0, opacity: 1, delay: 0.5, ease: Power3.easeInOut
			});
			
			//booking table
			TweenMax.from(".nc_book_table", 2, {
				y: 100 + "%", opacity: 0, ease: Power3.easeInOut
			});
			TweenMax.to(".nc_book_table", 2, {
				y: 0, opacity: 1, delay: 1, ease: Power3.easeInOut
			});
			
			//photo gallery page
			TweenMax.from("#photo_gallery_second .gallery_cover", 2, {
				x: -100 + "%", opacity: 0, ease: Power3.easeInOut
			});
			TweenMax.to("#photo_gallery_second .gallery_cover", 2, {
				x: 0, opacity: 1, delay: 0.5, ease: Power3.easeInOut
			});
			
			//video gallery page
			TweenMax.from(".nc_video_gallery .nc_video_thumb", 2, {
				x: -100 + "%", opacity: 0, ease: Power3.easeInOut
			});
			TweenMax.to(".nc_video_gallery .nc_video_thumb", 2, {
				x: 0, opacity: 1, delay: 0.5, ease: Power3.easeInOut
			});
			// animation define controller
			var controller = $.superscrollorama({
				triggerAtCenter: false,
				playoutAnimations: true,
				reverse: true
			});
			// amount of scrolling 
			var scrollDuration = 1;
			// individual element tween examples
			// welcome nightclub
			controller.addTween('.nc_header_main_home1', TweenMax.from($('.nc_thumb_wrapper.bottom_1'), 1.5, {
				opacity: 0, y: 80, ease: Power4.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_header_main_home1', TweenMax.to($('.nc_thumb_wrapper.bottom_1'), 1.5, {
				opacity: 1, y: 0, ease: Power4.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_header_main_home1', TweenMax.from($('.nc_thumb_wrapper.bottom_2'), 2, {
				opacity: 0, y: 120, ease: Power4.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_header_main_home1', TweenMax.to($('.nc_thumb_wrapper.bottom_2'), 2, {
				opacity: 1, y: 0, ease: Power4.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_header_main_home1', TweenMax.from($('.nc_thumb_wrapper.bottom_3'), 2.4, {
				opacity: 0, y: 160, ease: Power4.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_header_main_home1', TweenMax.to($('.nc_thumb_wrapper.bottom_3'), 2.4, {
				opacity: 1, y: 0, ease: Power4.easeInOut
			}), scrollDuration);
			
			//offer section
			controller.addTween('.nc_club_slider', TweenMax.from($('.offers_box_wrapper'), 1, {
				x: -200, opacity: 0, scale: 0.5, ease: Sine.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_club_slider', TweenMax.to($('.offers_box_wrapper'), 1, {
				x: 0, opacity: 1, scale: 1, ease: Sine.easeInOut
			}), scrollDuration);
			
			//photo gallery
			controller.addTween('.nc_event_main', TweenMax.from($('.home_gallery .gallery_cover'), 2, {
				x: -100 + "%", opacity: 0, ease: Power3.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_event_main', TweenMax.to($('.home_gallery .gallery_cover'), 2, {
				x: 0, opacity: 1, ease: Power3.easeInOut
			}), scrollDuration);
			
			//video crousel
			controller.addTween('.nc_track_wrapper', TweenMax.from($('.video_crousel'), 2, {
				x: -50, opacity: 0, ease: Expo.easeInOut
			}), scrollDuration);
			controller.addTween('.nc_track_wrapper', TweenMax.to($('.video_crousel'), 2, {
				x: 0, opacity: 1, ease: Expo.easeInOut
			}), scrollDuration);
			
			//recent blog
			controller.addTween('#testimonials', TweenMax.from($('.blog_cover'), 2, {
				y: 100, opacity: 0, ease: Power4.easeInOut
			}), scrollDuration);
			controller.addTween('#testimonials', TweenMax.to($('.blog_cover'), 2, {
				y: 0, opacity: 1, ease: Power4.easeInOut
			}), scrollDuration);
			
		}
	};
	nightclub.init();
	// Scroll Event
	$(window).on('scroll', function() {});
	//load event
	$(window).load(function() {
		// loader 
		$(".nc_preloader").delay(500).fadeOut("slow");
	});
	//Click event
	$('.gallery_cover, .sidebar_gallery').on('click', function() {
		$('.my_zoom_in .mfp-arrow').prepend('<i></i>');
		$('.image_fade .mfp-arrow').prepend('<i></i>');
		$('.mfp-arrow.mfp-arrow-left i').addClass('fa fa-caret-left');
		$('.mfp-arrow.mfp-arrow-right i').addClass('fa fa-caret-right');
	});
})(jQuery);