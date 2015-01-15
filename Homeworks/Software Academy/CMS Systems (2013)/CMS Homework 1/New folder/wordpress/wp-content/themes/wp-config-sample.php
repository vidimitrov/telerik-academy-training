<?php
// Last sync: r16131
// ** Настройки за MySQL ** //
define('DB_NAME', 'wordpress');     // Име на базата от данни
define('DB_USER', 'username');     // Вашето потребителско име за MySQL сървъра
define('DB_PASSWORD', 'password'); // ...и паролата
define('DB_HOST', 'localhost');     // Адрес на MySQL сървъра. 99% сигурно е, че е localhost
define('DB_CHARSET', 'utf8');
define('DB_COLLATE', '');

// Сложете различни тайни заклинения по-долу. Няма нужда да ги помните,
// така че може да са дълги и сложни.
// Посетете http://api.wordpress.org/secret-key/1.1/salt/
// за да си генерирате три автоматично или просто надвийте
// мързела си и измислете нещо:
define('AUTH_KEY',         'вашата супер-ултра-уникална фраза сложете тук');
define('SECURE_AUTH_KEY',  'вашата супер-ултра-уникална фраза сложете тук');
define('LOGGED_IN_KEY',    'вашата супер-ултра-уникална фраза сложете тук');
define('NONCE_KEY',        'вашата супер-ултра-уникална фраза сложете тук');
define('AUTH_SALT',        'вашата супер-ултра-уникална фраза сложете тук');
define('SECURE_AUTH_SALT', 'вашата супер-ултра-уникална фраза сложете тук');
define('LOGGED_IN_SALT',   'вашата супер-ултра-уникална фраза сложете тук');
define('NONCE_SALT',       'вашата супер-ултра-уникална фраза сложете тук');


// Представка за имената на таблиците. Променето го, ако искате да имате няколко
// WordPress инсталации, използващи една и съща база данни
// Моля, използвайте само букви на латиница и цифри!
$table_prefix  = 'wp_';   // примери: 'wp_', 'b2', 'mylogin_'

// Езикови настройки на WordPress.
// Ако искате да промените езика на различен от български променете стойността и сложете
// необходимия .mo файл в wp-content/languages
// Ако желаете да използвате езика по подразбиране (английски) сложете празен низ за език.
// Забележка: при промяна на езика темата по подразбиране ще остане на български език!
define ('WPLANG', 'bg_BG');

// Включете режим на debug ако сте разработчик
// Това включва допълнителни грешки и съобщения
define('WP_DEBUG', false);

/* Моля, не редактирайте нищо по-долу! И весело блогване :-) */

if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');
require_once(ABSPATH.'wp-settings.php');