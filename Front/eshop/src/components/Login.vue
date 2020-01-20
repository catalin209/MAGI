<template>
    <div v-if="!register" class="login-form">
        <div class="logo"/>
        <div class="form-group">
          <input type="text" required="required" v-model="username"/>
          <label for="input" class="control-label">Username</label><i class="bar"></i>
        </div>
        <div class="form-group">
          <input type="password" required="required" v-model="password"/>
          <label for="input" class="control-label">Password</label><i class="bar"></i>
        </div>
        <div class="button-container">
            <button class="login-button" @click="login">Login</button>
            <button class="login-button" @click="switchToRegister">Register</button>
        </div>
    </div>
    <div v-else class="login-form">
        <div class="logo"/>
        <div class="form-group">
          <input type="text" required="required" v-model="firstName"/>
          <label for="input" class="control-label">First Name</label><i class="bar"></i>
        </div>
        <div class="form-group">
          <input type="text" required="required" v-model="lastName"/>
          <label for="input" class="control-label">Last Name</label><i class="bar"></i>
        </div>
        <div class="form-group">
            <select v-model="countryId">
                <option v-for="country in countries" :value="country.id" :key="country.id">{{ country.name }}</option>
            </select>
            <label for="select" class="control-label">Country</label><i class="bar"></i>
        </div>
        <div class="form-group">
          <input type="text" required="required" v-model="username"/>
          <label for="input" class="control-label">Username</label><i class="bar"></i>
        </div>
        <div class="form-group">
          <input type="password" required="required" v-model="password"/>
          <label for="input" class="control-label">Password</label><i class="bar"></i>
        </div>
        <div class="button-container">
            <button class="login-button" @click="confirmRegistration">Confirm</button>
            <button class="login-button" @click="switchToRegister">Back</button>
        </div>
        
    </div>
</template>

<script>
    export default {
        data: () => {
            return {
                username: '',
                password: '',
                firstName: '',
                lastName: '',
                countryId: 0,
                register: false,
                countries: [
                    {
                        id: 1,
                        name: 'Romania'
                    },
                    {
                        id: 2,
                        name: 'France'
                    }
                ],
            }
        },

        methods: {
            login() {
                this.$emit('login', {username: this.username, password: this.password})
            },

            switchToRegister() {
                this.register = !this.register
            },

            confirmRegistration() {
                this.register = false
            },
        },
    }
</script>

<style scoped>
    @import '../assets/css/material-design-forms.css';
    .login-form {
        background: #fff;
        -webkit-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        -moz-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-direction: column;
        overflow: hidden;
        position: relative;
        width: 450px;
        min-height: 350px;
        position: absolute;
        top: calc(50% - 315px);
        left: calc(50% - 225px);
        margin: 0px;
        justify-content: center;
        overflow: visible;
    }
    .login-form .logo {
        background: url('../assets/dmag-logo.png') center no-repeat;
        width: 167px;
        height: 66px;
        margin-bottom: 5px;
        margin-top: 10px;
    }
    .login-form .reset-link {
        cursor:pointer;
        color: #008CBA;
        text-decoration:none;
        margin-bottom: 5px;
        font-style: italic;
    }
    .login-form .reset-link:hover {
        text-decoration:underline;
    }
    .login-form .login-button {
        display: inline-block;
        font-weight: 700;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;
        -ms-touch-action: manipulation;
        touch-action: manipulation;
        cursor: pointer;
        background-image: none;
        border: 1px solid transparent;
        font-size: 14px;
        line-height: 1.42857143;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        color: #333;
        background-color: #d3d3d3;
        border-color: #ddd;
        width: 100px;
        height: 35px;
        display: flex;
        justify-content: center;
        align-items: center;
        margin-bottom: 15px;
        outline: none;
    }
    .login-form .form-group {
        width: calc(100% - 80px);
    }
    .login-form .form-group:first-child {
        margin-top: 0px;
    }
    .login-form .button-container {
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        margin-bottom: 10px;
        width: 80%;
    }
</style>