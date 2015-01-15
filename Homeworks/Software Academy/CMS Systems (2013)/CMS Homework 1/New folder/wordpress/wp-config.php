<?php
// Last sync: r16131
// ** Настройки за MySQL ** //
define('DB_NAME', 'wordpress');     // Име на базата от данни
define('DB_USER', 'root');     // Вашето потребителско име за MySQL сървъра
define('DB_PASSWORD', ''); // ...и паролата
define('DB_HOST', 'localhost');     // Адрес на MySQL сървъра. 99% сигурно е, че е localhost
define('DB_CHARSET', 'utf8');
define('DB_COLLATE', '');

// Сложете различни тайни заклинения по-долу. Няма нужда да ги помните,
// така че може да са дълги и сложни.
// Посетете http://api.wordpress.org/secret-key/1.1/salt/
// за да си генерирате три автоматично или просто надвийте
// мързела си и измислете нещо:
define('AUTH_KEY',         ']#!LG~+B($FZ{eTyeFAQ0jm5WphLFN-,2A.Yk}1^t9bs7iAh_{d9R2aIz +REl {');
define('SECURE_AUTH_KEY',  'cj=XF+5RaC(j{eyM3[u3Bsx~|,H~{|p,GHnxN0VY7E,aRZc,z=CIBo$t18:TQ62o');
define('LOGGED_IN_KEY',    'fz5DwiP} _V}`Lb#{j )H`3Sgjc(,(VmYhpFe-t^QQM^SsB<k.JR<b2*6Zf})w!V');
define('NONCE_KEY',        ']t_@r*x-T~lP0M<+=&I*E7Z?|0`jjf.82bp~+fvDMiF5#h$UW^lQ_%VmT:a7@p)}');
define('AUTH_SALT',        '16:1ut~7UB41|/!]]LPojg`NZr5r<v{V(Un@fo=q-TsRM]48unxB-DRFt*5T&~g-');
define('SECURE_AUTH_SALT', 'du[l]W$AC*_-Xq9[^@rk^_0Swznem,t,D8O|AzCF8?/Q,(|i D[@[6l~~ ;{efSx');
define('LOGGED_IN_SALT',   'GwN&siI_7L^R|E*BKVm&lg`]O^N9@~|//8]ib{$>vNb[-=_h:3X38Nt%a!}Va8@ ');
define('NONCE_SALT',       'G@$E*,wY>gM8:fyOAtj7pa%xq^i:PuEg:e.pld2HNSwbF2:s85&UJ~Ai|Uky(~p0');


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