<script setup>
    import { useSlots } from 'vue'
    const props = defineProps({
        title: {
            type: String,
            required: true,
        },
        fieldNames: {
            type: Array,
            required: true,
        },
        tableBody: {
            // type: Array,
            // required: false,
        },
    })

    const emits = defineEmits([`test`,'inFocus', 'handleSubmit']);
    function handleSubmit() {
        //$emit('handleSubmit');
            alert('handleSubmit');
    };


const slots = useSlots()
console.log(`slots`, slots)

</script>

<template>
        <div class="modal-content">
            <div class="modal-header">
            <h5 class="modal-title">{{ title }}</h5>

            <button
                    aria-label="Close"
                    class="close"
                    data-dismiss="modal"
                    type="button"
                    @click="$emit('closeEvent')">
                <span aria-hidden="true">&times;</span>
            </button>

        </div>
        <div class="modal-body">
            <form>
                <div class="mb-3">
                    <label class="form-label">email:</label>
                    <input
                        id="memberemail"
                        class="form-control"
                        placeholder="Enter email"
                        type="text"/>
                </div>
                <div class="mb-3">
                    <label class="form-label">password:</label>
                    <input
                        id="memberpassword"
                        class="form-control"
                        placeholder="Enter password"
                        type="password"/>
                </div>
                <!-- Button group-->
                <div class="btn-group" role="group">
                    <!-- <slot name="submit"></slot> -->
                    <button type="button" @click="handleSubmit">buttonClick</button>
                    <button
                        class="btn btn-danger btn-sm"
                        type="reset">
                        Reset
                    </button>
                    <slot name="test"></slot>

                    <button type="button" @click="$emit('someEvent')">click me</button>
                </div>
            </form>
        </div>
      </div>
</template>

