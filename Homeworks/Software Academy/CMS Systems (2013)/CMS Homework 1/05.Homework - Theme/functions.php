<?php
	$sidebar_args = array(
		'id' => 'right-sidebar',
		'name' => 'Main Sidebar',
		'before_widget' => '<div class="sidebar">',
		'after_widget'  => '</div>',
	);
	
	register_sidebar( $sidebar_args );
		
	register_nav_menu( 'top-site-menu' , 'This is top site menu' );
	