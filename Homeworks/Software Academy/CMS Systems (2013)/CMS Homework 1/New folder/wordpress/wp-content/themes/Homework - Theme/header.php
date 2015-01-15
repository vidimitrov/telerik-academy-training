<!DOCTYPE HTML>
<html>

<head>
  <title><?php wp_title(' '); ?></title>
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  <link rel="stylesheet" type="text/css" href="<?php bloginfo('stylesheet_url');?>" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="<?php bloginfo('template_url'); ?>/js/modernizr-1.5.min.js"></script>
</head>

<body>
  <div id="main">
    <header>
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a href="index.html">CSS3<span class="logo_colour">_six_dark</span></a></h1>
          <h2>Simple. Contemporary. Website Template.</h2>
        </div>
      </div>
	  <nav>
		<?php wp_nav_menu(array(
			'theme_location' => 'top-site-menu',
			'container' => 'div',
			'container_id' => 'menu_container',
			'menu_class' => 'sf-menu',
			'menu_id' => 'nav'
		));?>
	  </nav>
    </header>
	<div id="site_content">