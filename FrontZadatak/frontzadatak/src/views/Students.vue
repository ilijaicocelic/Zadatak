<template>
    <div>
         <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.username}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.username}}">Courses</router-link>|
          <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all students</h1>
        <b-table striped hover :items="students">
            <template #cell(name)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/profile/${currentUser.username}/${data.index}`">
               {{ data.value }}
                  </router-link>
             </template>
       </b-table>
       <button @click="toggleStudForm" class="btn btn-primary"> Add New Student</button>
       <b-form @submit.prevent="handleSubmit"  v-if="showStudForm">
        <br>
      <b-form-group id="input-group-2" label="Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.name"
          placeholder="Enter name"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Surname:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.surname"
          placeholder="Enter surname"
          required
        ></b-form-input>
      </b-form-group>
       <b-form-group id="input-group-2" label="Index Number:" label-for="input-2">
        <b-form-input
          id="input-2"
          type="text"
          v-model="formData.indexNumber"
          placeholder="Enter index number..."
          required
        ></b-form-input>
      </b-form-group>
        <b-form-group id="input-group-3" label="Year:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="formData.year"
          :options="years"
          required
        ></b-form-select>
      </b-form-group>
       <b-form-group id="input-group-3" label="Type:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="formData.type"
          :options="types"
          required
        ></b-form-select>
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
            showStudForm: false,
            formData: {
                name: '',
                surname: '',
                indexNumber: '',
                year: null,
                type: null,
                role: 1
            },
            years: [{ text: 'Select One', value: null }, 1, 2, 3, 4],
            types: [{ text: 'Select One', value: null }, 'Regular', 'Advanced'],
            show: true
        }
    },
    computed: {
        ...mapState([
            'students'
        ])
    },
    methods: {
        ...mapActions([
            'addStudent'
        ]),
        toggleStudForm () {
            this.showStudForm = !this.showStudForm
        },
        handleSubmit () {
            const { name, surname, indexNumber, year, type, role } = this.formData
            const payload = {
                student: {
                    name,
                    surname,
                    indexNumber,
                    year,
                    type,
                    role
                 }
            }
            this.addStudent(payload)

            this.formData = {
                name: '',
                surname: '',
                indexNumber: '',
                year: null,
                type: null,
                role: 1
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
