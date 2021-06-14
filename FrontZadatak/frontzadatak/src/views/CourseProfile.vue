<template>
    <div>
             <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.id}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.id}}">Courses</router-link>|
       <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" > {{ clickedCourse.name }} </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <br>
        <br>
        <br>
        <h4 class="text-monospace" >Course name: {{ clickedCourse.name }} </h4>
         <h4 class="text-monospace" >Head Teacher : {{ clickedCourse.teacher }} </h4>
         <br>
         <button @click="toggleCourseForm" class="btn btn-primary"> Modify Course Info</button>
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
            currentUser: {},
            clickedCourse: {},
            id1: {},
            id2: {},
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
            const data = { name: this.name, teacher: this.teacher }
              this.axios.put('http://localhost:62612/api/course/ModifyCourse/' + this.id2, data)
            .then((respond) => {
                this.id2 = this.$route.params.id
              this.axios.get('http://localhost:62612/api/course/GetCourse/' + this.id2)
            .then((respond) => {
                this.clickedCourse = respond.data
             })
             })
        }
    },
    mounted () {
        this.id1 = this.$route.params.userId
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.currentUser = respond.data
             })

         this.id2 = this.$route.params.id
              this.axios.get('http://localhost:62612/api/course/GetCourse/' + this.id2)
            .then((respond) => {
                this.clickedCourse = respond.data
             })
    }
}
</script>
