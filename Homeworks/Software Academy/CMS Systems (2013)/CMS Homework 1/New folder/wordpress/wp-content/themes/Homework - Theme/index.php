<?php get_header();	?>
<?php get_sidebar('right-sidebar'); ?>
      
	<div class="content">
	
		<?php
			if(have_posts()):
				while(have_posts()):
					the_post();
		?>
		
		<h2><?php the_title(); ?></h2>
		<div>
			<?php the_content(); ?>
		</div>
		
		<!-- Content goes here-->
		
		<?php endwhile; else: ?>
		<p><?php _e('Sorry, no posts matched your criteria.'); ?></p>
		<?php endif; ?>
		
	</div>
	
<?php get_footer();	?>