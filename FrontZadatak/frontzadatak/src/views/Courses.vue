<template>
    <div>
        <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.id}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.id}}">Courses</router-link>|
       <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all courses</h1>
        <b-table striped hover :items="courses">
            <template #cell(id)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/courseprofile/${currentUser.id}/${data.value}`">
               {{ data.value }}
                  </router-link>
             </template>
     </b-table>
      <button @click="toggleCourseForm" class="btn btn-primary"> Add New Course</button>
       <b-form @submit.prevent="handleSubmit"  v-if="showCourseForm">
        <br>
      <b-form-group id="input-group-2" label="Course Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="name"
          placeholder="Enter course name..."
          required
        ></b-form-input>
      </b-form-group> <b-form-group id="input-group-2" label="Head Teacher:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="teacher"
          placeholder="Enter the head teacher..."
          required
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
       </b-form>
    </div>
</template>

<script>

export default {
    data () {
        return {
            courses: [],
            currentUser: {},
            id1: '',
            showCourseForm: false,
            name: '',
            teacher: ''
        }
    },
    methods: {
        toggleCourseForm () {
            this.showCourseForm = !this.showCourseForm
        },
         handleSubmit (event) {
            event.preventDefault()

            var data = { name: this.name, teacher: this.teacher }
            this.axios.post('http://localhost:62612/api/course/AddCourse', data)
            .then((respond) => {
                this.axios.get('http://localhost:62612/api/course/GetAllCourses')
            .then((respond) => {
                this.courses = respond.data
                this.showCourseForm = false
                this.name = ''
                this.teacher = ''
             })
             })
        }
    },
     mounted () {
         this.axios.get('http://localhost:62612/api/course/GetAllCourses')
            .then((respond) => {
                this.courses = respond.data
             })

         this.id1 = this.$route.params.userId
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.currentUser = respond.data
             })
    }
}
</script>
