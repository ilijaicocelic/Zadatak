<template>
  <div>
       <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/NonLogedStudents">Students</router-link>|
      <router-link to="/NonLogedCourses">Courses</router-link>|
    </div>
     <h1 class="text-monospace" >Welcome to the FTN homepage</h1>
     <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
    <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
     <h3 class="text-monospace" >Please Login to continue... </h3>
     <br>
     <br>
     <br>
     <b-form @submit="login" >
    <b-form-group
      id="fieldset-1"
      description="Note: at least 4 characters."
    label="Enter your username"
      label-for="input-1"
      valid-feedback="Thank you!"
      :invalid-feedback="invalidFeedback"
      :state="state"
    >
      <b-form-input id="input-1" v-model="username" :state="state" trim></b-form-input>
    </b-form-group>
    <br>
     <b-form-group
      id="fieldset-2"
      description="Note : at least 6 characters"
      label="Enter your password"
      label-for="input-2"
      valid-feedback="Thank you!"
      :invalid-feedback="invalidFeedback1"
      :state="state1"
    >
      <b-form-input id="input-2" v-model="password" :state="state1" trim></b-form-input>
    </b-form-group>
    <br>
        <b-button type="submit" variant="primary"  >   CONFIRM   </b-button>
    </b-form>
  </div>
</template>

<script>
import students from '../data/students'
import router from '../router/index'

  export default {
    name: 'home',
    data () {
      return {
        students,
        user1: {},
        username: '',
        password: '',
        isDisabled: true
      }
    },
    computed: {
      state () {
          if (this.username.length >= 4) {
              return true
          } else if (this.username.length === 0) {
              return null
          } else {
              return false
          }
      },
      state1 () {
          if (this.password.length >= 6) {
              return true
          } else if (this.password.length === 0) {
              return null
          } else {
              return false
          }
      },
      invalidFeedback () {
        if (this.username.length > 0) {
          return 'Enter at least 4 characters.'
        }
        return 'Please enter something.'
      },
      invalidFeedback1 () {
          if (this.password.length > 0) {
              return 'Password to short'
          } else if (this.password.length === 0) {
              return null
          } else {
              return 'Enter your password please'
          }
      }
    },
    methods: {
        login (event) {
            event.preventDefault()
            // for (let index = 0; index < this.students.length; index++) {
            //    if (this.students[index].username === this.username && this.students[index].password === this.password && this.students[index].role === 0) {
            //      this.user1 = this.students[index]
            //      this.isDisabled = false
            //    }
            // }
            var data = { username: this.username, password: this.password }
            this.axios.post('http://localhost:62612/api/user/login', data)
            .then((respond) => {
                localStorage.token = respond.data.token
                this.user1 = respond.data.user
                router.push({ name: 'students', params: { userId: this.user1.id } })
            })
            .catch(() => {
                alert('Sorry we can not log u')
            }
            )
        }
    }
  }
</script>
