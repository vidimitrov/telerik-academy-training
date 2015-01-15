define(function() {
    "use strict";

    var Course;

    Course = (function() {
        function Course(title, formula) {
            this._formula = formula;
            this._students = [];
            this.title = title;
        }

        function getSortedStudents(students, count, sortBy) {
            var sortedStudents = students.sort(function(student1, student2) {
                return  student2[sortBy] - student1[sortBy];
            }).slice(0, count);

            return sortedStudents;
        }

        Course.prototype = {
            addStudent: function(student) {
                this._students.push(student);
            },
            calculateResults: function() {
                var self = this;
                this._students.forEach(function(student) {
                    student.totalScore = self._formula(student);
                });
            },
            getTopStudentsByExam: function(count) {
                return getSortedStudents(this._students, count, 'exam');
            },
            getTopStudentsByTotalScore: function(count) {
                return getSortedStudents(this._students, count, 'totalScore');
            }
        };

        return Course;
    }());

    return Course;
});