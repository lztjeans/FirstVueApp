<script setup>

</script>
<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-10">
        <h1>Here is the list of Employees</h1>
        <hr/>
        <!-- <br/><br/> -->
        <alert v-if="showMessage" :message="message"></alert>
        <button
            class="btn btn-success btn-sm"
            type="button"
            @click="toggleAddMemberModal">
          Add Member
        </button>
        <br/><br/>
        <table class="table table-hover" border="5">
          <thead>
            <tr>
              <th scope="col">ID</th>
              <th scope="col">Name</th>
              <th scope="col">Age</th>
              <th scope="col">Salary</th>
              <th scope="col">Department</th>
              <th scope="col">Sex</th>
              <th scope="col">Email</th>
              <th>action1</th>
              <th>action2</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(e, index) in Members" :key="index">
              <td>{{ e.id }}</td>
              <td>{{ e.username }}</td>
              <td>{{ e.age }}</td>
              <td>{{ e.salary }}</td>
              <td>{{ e.email  }}</td>
              <td>{{ e.department }}</td>
              <td>
                <span v-if="e.sex == 'F'">Female</span>
                <span v-else>Male</span>
              </td>
            <td>
              <div class="btn-group" role="group">
                <button
                    class="btn btn-warning btn-sm"
                    type="button"
                    @click="toggleEditMemberModal(e)">
                  Update
                </button>
                <button
                    class="btn btn-danger btn-sm"
                    type="button"
                    @click="handleDeleteMember(e)">
                  Delete
                </button>
              </div>
            </td>
          </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
  <!-- add new Member modal -->
  <div v-show="activeAddMemberModal" class="modal-backdrop fade show">
  </div>
  <formmodal :action="action" :members="Members"/>
  <!-- edit Member modal -->
<!-- <formmodal /> -->
  <!-- <div v-if="activeEditMemberModal" class="modal-backdrop fade show"></div> -->
</template>

<script>
import axios from "axios";
import Alert from "./Alert.vue";
import FormModal from './FormModal.vue';

export default {  
  data() {
    return {
      activeAddMemberModal: false,
      // addMemberForm: {
      //   id: "",
      //   username: "",
      //   age: "",
      //   salary: "",
      //   department: "",
      //   sex: [],
      //   email: ""
      // },
      activeEditMemberModal: false,
      // editMemberForm: {
      //   id: '',
      //   username: '',
      //   age: '',
      //   salary: '',
      //   department: '',
      //   sex: [],
      //   email: ''
      // },
      Members: [],
      message: "",
      showMessage: false,
      action: ""
    };
  },
  components: {
    alert: Alert,
    formmodal: FormModal,
  },
  methods: {
    toggleAddMemberModal() {
      this.action = "Add";
      this.Members={};
      const body = document.querySelector("body");
      this.activeAddMemberModal = !this.activeAddMemberModal;
      if (this.activeAddMemberModal) {
        body.classList.add("modal-open");
      } else {
        body.classList.remove("modal-open");
      }
      console.log(this.activeAddMemberModal);
    },
    toggleEditMemberModal(Member) {
      this.action = "Edit";
      this.Members = Member;

      if (Member) {
        this.editMemberForm = Member;
      }
      const body = document.querySelector("body");
      this.activeEditMemberModal = !this.activeEditMemberModal;
      if (this.activeEditMemberModal) {
        body.classList.add("modal-open");
      } else {
        body.classList.remove("modal-open");
      }
    },
    handleDeleteMember(Member) {
      this.removeMember(Member.id);
    },
    removeMember(MemberID) {
      const path = `http://localhost:5001/Members/${MemberID}`;
      axios.delete(path)
          .then(() => {
            this.getMembers();
            this.message = 'Member removed!';
            this.showMessage = true;
          })
          .catch((error) => {
            console.error(error);
            this.getMembers();
          });
    },
    getMembers() {
      const path = "http://localhost:5001/Members";
      // const path ="https://localhost:44396/Employee";
      axios
          .get(path)
          .then((res) => {
            this.Members = res.data.Members;
          })
          .catch((error) => {
            console.error(error);
          });
    },
  },
  created() {
    console.log("component: 'Members' created!");
    // this.getMembers();
  },
};
</script>
