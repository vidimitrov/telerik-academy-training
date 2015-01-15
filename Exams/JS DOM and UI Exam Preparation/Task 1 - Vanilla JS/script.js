function createCalendar(selector, events){
    var DAYS_IN_MONTH = 30;
    var DAYBOX_WIDTH = 110;
    var DAYBOX_HEIGHT = 110;

    var calendarContainer = document.querySelector(selector);
    calendarContainer.style.width = 7.5 * DAYBOX_WIDTH + 'px';

    var dayBox = document.createElement('div');
    var dayBoxTitleContainer = document.createElement('div');
    var dayBoxEvents = document.createElement('div');
    dayBoxEvents.style.float = 'left';

    dayBox.appendChild(dayBoxTitleContainer);
    dayBox.appendChild(dayBoxEvents);

    dayBox.style.width = DAYBOX_WIDTH + 'px';
    dayBox.style.height = DAYBOX_HEIGHT + 'px';
    dayBox.style.border = '1px solid black';
    dayBox.style.display = 'inline-block';

    dayBoxTitleContainer.style.color = '#111';
    dayBoxTitleContainer.style.backgroundColor = '#BBB';
    dayBoxTitleContainer.style.textAlign = 'center';
    dayBoxTitleContainer.style.borderBottom = '1px solid black';

    var selectedBox = null;
    var boxes = [];

    for(var i = 1; i <= DAYS_IN_MONTH; i++){
        var title = '';
        var hour = '';

        for(var j = 0; j < events.length; j++){
            if(events[j].date == i){
                title = events[j].title;
                hour = events[j].hour;
            }
        }

        var box = dayBox.cloneNode(true);
        var boxChildren = box.childNodes;

        var date = new Date(2014, 06, i);
        boxChildren[0].innerHTML = date.toDateString();
        boxChildren[1].innerHTML = hour + ' ' + title;

        boxes.push(box);
    }

    function onBoxClick(){
        if(selectedBox){
            this.childNodes[0].style.backgroundColor = '#BBB';
        }
        if(selectedBox === this){
            selectedBox = null;
        }
        else{
            this.childNodes[0].style.backgroundColor = '#EEE';
            selectedBox = this;
        }
    }

    for(var i = 0; i < boxes.length; i++){
        boxes[i].addEventListener('click', onBoxClick);

        boxes[i].addEventListener('mouseover', function(){
            this.childNodes[0].style.backgroundColor = '#777';
        });

        boxes[i].addEventListener('mouseout', function(){
            this.childNodes[0].style.backgroundColor = '#BBB';
        });
        calendarContainer.appendChild(boxes[i]);
    }
}