<template>
    <div class="container">
        <div class="row">
            
            <div class="col-sm-10">
                <h1>Here is the list of Products</h1>
                <hr/>
                <alert v-if="showMessage" :message="message"></alert>
                <button
                class="btn btn-success btn-sm"
                type="button"
                @click="handleClick(action_C)">
                Add Product
                </button>
                <br/><br/>

                <MyTable :tableHeads="tableHeads" :tableBody="tableBody">
                <template #updateLink="{ index, props, value }">
                        <button type="button" @click="handleClick(action_U,value)">Update</button>
                </template>
                <template #deleteLink="{index, props, value }">
                    <button type="button" @click="handleClick(action_D,value)">Delete</button>
                </template>
                </MyTable>
            </div>
        </div>
    </div>


    <!-- black backgroud-->
    <div v-show="activeModal" class="modal-backdrop fade show"></div>

    <!-- add or edit modal -->
    <div :class="{ show: activeModal , 'd-block': activeModal}" class="modal fade" role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <ProductForm :title="action" 
                         :fieldNames="['a,b,c,d,e']" 
                         @someEvent="callback"
                         @closeEvent="handleCloseModal" >



                <!-- <template #submit>
                    <button
                        class="btn btn-primary btn-sm"
                        type="button"
                        @click="handleSubmit(action)">
                        Submit
                    </button>
                </template> -->
                <template #test>test</template>
            </ProductForm>
        </div>
    </div>

</template>





<script setup> 
import MyTable from '../shared/Mytable.vue';
import ProductForm from '../shared/ProductForm.vue';
import Alert from "../shared/Alert.vue";
import axios from "axios";

</script>


<script> 
const tableHeads = [ 'Name', 'Description', 'Price', 'Picture', 'Type Name', 'Brand', 'Update', 'Delete']
const hostname = "http://localhost:5001/"
var action="default Title";
const action_C="Create";
const action_U="Update";
const action_D="Delete";

export default {  
    data() {
        return {
            showMessage: false,
            message: "",
            activeModal: false,
            tableBody: null,
            bodyData: {                
                name: 'abc',
                description: 'desc',
                price: '1',
                pic: '33',
                typename: '123',
                brand: 'e1f',
                updateLink: '2',
                deleteLink: '3',
            },
        }
    },
    methods: {
        handleClick(a, val){
            this.showMessage=true;
            action=a;
            switch(a){
                case action_C:
                    this.activeModal = true;
                    this.message=('Add new item!');
                    break;
                case action_U:
                this.activeModal = true;
                    this.message=("Update this item now... redir :" + val)
                    break;
                case action_D:                    
                    this.message=("This item was deleted by " + val);
                    break;
            }
        },
        handleCloseModal(){
            this.activeModal=false;

        },
        handleSubmit() {
            switch (action) {
                case action_C:
                this.handleCloseModal();
                alert( action + ' submit');
                // this.addMember(this.memberForm);
                // this.initForm();
                break;
                case action_U:
                this.handleCloseModal();
                // this.updateMember(this.memberForm);
                break;
                default:
                break;
            }
        },
        getAllProducts(){
            const path =hostname+"prod/list";
            axios.get(path)
                .then((res) => {
                    this.tableBody = res.data;
                    console.log(res.data);
                })
                .catch((error) => {
                    console.error(error);
                });
            console.log("getAllProducts done");
        },
        callback(){
            alert('callback!!');
        }

    },
    created(){
        console.log('List started creating...')
        this.getAllProducts();
        console.log('List be created!');
    },

}
</script>


<style>
table,
th,
td {
  border: 1px solid;
}

tr,
th {
  padding: 5px;
}
</style>