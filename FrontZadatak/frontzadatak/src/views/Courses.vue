<template>
    <div>
        <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.username}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.username}}">Courses</router-link>|
       <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all courses</h1>
        <b-table striped hover :items="courses">
            <template #cell(name)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/courseprofile/${currentUser.username}/${data.index}`">
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
       <b-form-group id="input-group-2" label="Course Code: " label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.courseCode"
          placeholder="Enter course code for your course.."
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
            'addCourse'
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
            this.addCourse(payload)

            this.formData = {
                name: '',
                headTeacher: '',
                courseCode: ''
            }
        }
    },
     mounted () {
        const temp = this.$route.params.userId
        for (let index = 0; index < this.students.length; index++) {
            if (this.students[index].username === temp) {
                this.currentUser = this.students[index]
            }
        }
    }
}
</script>
