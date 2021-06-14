<template>
    <div>
         <div id="nav">
       <router-link :to="{ name: 'students', params: { userId: currentUser.id}}">Students</router-link>|
       <router-link :to="{ name: 'courses', params: { userId: currentUser.id}}">Courses</router-link>|
          <router-link to="/">
        <b-button type="submit" @click="login" variant="danger"  >   Logout   </b-button>
    </router-link>
    </div>
        <h1 class="text-monospace" >List of all students</h1>
        <b-table striped hover :items="students">
            <template #cell(id)="data">
        <!-- `data.value` is the value after formatted by the Formatter -->
             <router-link :to="`/profile/${currentUser.id}/${data.value}`">
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

export default {
    data () {
        return {
            students: [],
            currentUser: {},
            id1: '',
            id2: '',
            showStudForm: false
        }
    },
    methods: {
        toggleStudForm () {
            this.showStudForm = !this.showStudForm
        },
        handleSubmit () {
        }
    },
    mounted () {
        this.axios.get('http://localhost:62612/api/user/GetAllUsers')
            .then((respond) => {
                this.students = respond.data
             })

              this.id1 = this.$route.params.userId
              this.axios.get('http://localhost:62612/api/user/getUser/' + this.id1)
            .then((respond) => {
                this.currentUser = respond.data
             })
    }
}
</script>
