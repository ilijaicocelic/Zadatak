<template>
    <div>
             <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.username}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.username}}">Courses</router-link>|
       <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" > {{ currentCourse.name }} </h1>
        <b-img left src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Left image"></b-img>
        <b-img right src="https://www.prijemni.rs/files/institution/institution_37/logo.jpg" alt="Right image"></b-img>
        <br>
        <br>
        <br>
        <h4 class="text-monospace" >Course name: {{ currentCourse.name }} </h4>
         <h4 class="text-monospace" >Head Teacher : {{ currentCourse.headTeacher }} </h4>
         <br>
         <button @click="toggleCourseForm" class="btn btn-primary"> Modify Course Info</button>
       <b-form @submit.prevent="handleSubmit"  v-if="showCourseForm">
        <br>
      <b-form-group id="input-group-2" label="Course Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.name"
          placeholder="Enter course name..."
          required
        ></b-form-input>
      </b-form-group> <b-form-group id="input-group-2" label="Head Teacher:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.headTeacher"
          placeholder="Enter the head teacher..."
          required
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
       </b-form>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
    data () {
        return {
            currentUser: {},
            currentCourse: {},
            showCourseForm: false,
             formData: {
                name: '',
                headTeacher: '',
                courseCode: ''
            }
        }
    },
    computed: {
        ...mapState([
            'courses',
            'students'
        ])
    },
    methods: {
        ...mapActions([
            'modifyCourse'
        ]),
        toggleCourseForm () {
            this.showCourseForm = !this.showCourseForm
        },
         handleSubmit () {
            const { name, headTeacher, courseCode } = this.formData
            const payload = {
                course: {
                    name,
                    headTeacher,
                    courseCode
                 }
            }
            this.currentCourse.name = this.formData.name
            this.currentCourse.headTeacher = this.formData.headTeacher
            this.modifyCourse(payload)
            this.formData = {
                name: '',
                headTeacher: '',
                courseCode: ''
            }
        }
    },
    mounted () {
        const temp = this.courses[this.$route.params.id]
        this.currentCourse = temp
        this.formData.courseCode = temp.courseCode

           const temp1 = this.$route.params.userId
        for (let index = 0; index < this.students.length; index++) {
            if (this.students[index].username === temp1) {
                this.currentUser = this.students[index]
            }
        }
    }
}
</script>
