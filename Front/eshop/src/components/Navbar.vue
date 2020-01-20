<template>
    <div class="nav">
        <div class="logo-container">    
            <div class="logo"></div>
        </div>
        <div class="search-container">
            <div class="form-group name">
                <input type="text" v-model="globalSearchName"/>
                <label for="input" class="control-label"></label><i class="bar"></i>
                <i class="search-icon" @click="globalSearch"/>
            </div>
        </div>
        <div class="nav-buttons-container">
            <div class="nav-button action"><i class="cart"/>My Cart</div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            selectedTab: {
                type: Number,
                default: 2
            },
            selectedGlobalSearchName: {
                type: String,
                default: ''
            },
        },

        data: () => {
            return {
                globalSearchName: '',
            }
        },

        methods: {
            selectTab(index) {
                this.$emit('selectTab', index)
            },
            globalSearch() {
                this.$emit('globalSearch', this.globalSearchName)
            },
        },
    }
</script>

<style scoped>
    @import '../assets/css/material-design-forms.css';
    .nav {
        background: #fff;
        -webkit-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        -moz-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        width: 100%;
        position: fixed;
        top: 0px;
        left: 0px;
        height: 80px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .nav .logo {
        background: url('../assets/dmag-logo.png') center no-repeat;
        width: 167px;
        height: 66px;
    }
    .nav .logo-container {
        height: 100%;
        flex: 1;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .nav .search-container {
        height: 100%;
        flex: 3;
        display: flex;
        justify-content: center;
        align-items: center;
    } 
    .nav .search-container .form-group {
        width: calc(100% - 20px);
        margin: 20px;
        margin-top: 25px;
    }
    .nav .search-container .form-group .search-icon {
        background: url('../assets/search.png') center no-repeat;
        width: 24px;
        height: 24px;
        cursor: pointer;
        position: absolute;
        right: 10px;
        bottom: 7px;
        transform: scale(0.9);
    }
    .nav .search-container .form-group .search-icon:hover {
        transform: scale(1);
    }
    .nav .nav-buttons-container {
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        position: relative;
        flex: 1;
        overflow: hidden;
    }
    .nav .nav-button {
        color: #000;
        font-weight: 400;
        font-size: 18px;
        text-transform: uppercase;
        min-width: 140px;
        max-width: 140px;
        height: calc(100% - 15px);
        margin: 0px 30px;
        display: flex;
        justify-content: center;
        align-items: center;
        position: relative;
        text-align: center;
    }
    .nav .nav-button .cart {
        background: url('../assets/shopping-cart.png') center no-repeat;
        width: 24px;
        height: 24px;
        margin-right: 10px; 
    }
    .nav .nav-button.action {
        cursor: pointer;
    }
    .nav .nav-button.action label {
        cursor: pointer;
    }
    .nav .nav-button .user {
        font-weight: 400;
        font-size: 16px;
        text-transform: none;
        font-style: italic;
    }
    .nav .nav-button:last-child {
        width: auto;
    }
    .nav .nav-buttons-container .active {
        position: absolute;
        border-bottom: 3px solid #41b883;
        bottom: 5px;
        width: 200px;
        transition: right 0.45s;
    }
</style>