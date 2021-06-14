import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Students from '../views/Students.vue'
import Courses from '../views/Courses.vue'
import Profile from '../views/Profile.vue'
import CourseProfile from '../views/CourseProfile.vue'
import NonLogedStudents from '../views/NonLogedStudents.vue'
import NonLogedCourses from '../views/NonLogedCourses.vue'
import NonLogedProfile from '../views/NonLogedProfile.vue'
import NonLogedCP from '../views/NonLogedCP.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/students/:userId',
    name: 'students',
    component: Students
  },
  {
    path: '/courses/:userId',
    name: 'courses',
    component: Courses
  },
  {
    path: '/profile/:userId/:id',
    name: 'profile',
    component: Profile
  },
  {
    path: '/courseprofile/:userId/:id',
    name: 'courseprofile',
    component: CourseProfile
  },
  {
     path: '/NonLogedStudents',
     name: 'NonLogedStudents',
     component: NonLogedStudents
  },
  {
      path: '/NonLogedCourses',
      name: 'NonLogedCourses',
      component: NonLogedCourses
  },
  {
      path: '/NonLogedProfile/:id',
      name: 'NonLogedProfile',
      component: NonLogedProfile
  },
  {
      path: '/NonLogedCP/:id',
      name: 'NonLogedCP',
      component: NonLogedCP
  }
]

const router = new VueRouter({
  routes
})

export default router
