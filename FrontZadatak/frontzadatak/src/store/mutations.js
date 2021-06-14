export default {
    appendStud: (state, { student }) => {
        state.students.push(student)
    },
    changeStud: (state, { student }) => {
        for (let index = 0; index < state.students.length; index++) {
            if (state.students[index].username === student.username) {
                state.students[index] = student
            }
        }
    },
    appendCourse: (state, { course }) => {
        state.courses.push(course)
    },
    changeCourse: (state, { course }) => {
        for (let index = 0; index < state.courses.length; index++) {
            if (state.courses[index].courseCode === course.courseCode) {
                state.courses[index] = course
            }
        }
    },
    loginUser: (state, { loginform }) => {
        for (let index = 0; index < state.students.length; index++) {
            if (state.students[index].username === loginform.username && state.students[index].password === loginform.password) {
                return state.students[index]
            }
        }
    }
}
