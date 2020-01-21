<template>
<div class="popup-overlay">
    <div class="cart-form">
        <div class="close-popup" @click="closePopup">X</div>
        <div v-if="products.length > 0" class="products-container">
            <div class="product-container" v-for="product in products" :key="product.id">
                <img :src="`/product-${product.id}.png`"/>
                <span class="name">{{`${product.id} - ${product.name}`}}</span>
                <span class="price">{{product.price}}&#x24;</span>
                <button class="btn" @click="removeItem(product.id)">Remove <i class="remove"/></button>
            </div>
        </div>
        <div class="button-container">
            <button class="cart-button">Checkout</button>
        </div>
    </div>
</div>
    
</template>

<script>
    export default {
        props: {
            shopCartData: {
                type: Array
            },
        },

        created() {
            this.products = this.shopCartData
        },

        data: () => {
            return {
                products: [
                    // {
                    //     id: 1,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 100
                    // },
                    // {
                    //     id: 2,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 200
                    // },
                    // {
                    //     id: 3,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 300
                    // },
                    // {
                    //     id: 4,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 400
                    // },
                    // {
                    //     id: 5,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 500
                    // },
                    // {
                    //     id: 6,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 600
                    // },
                    // {
                    //     id: 7,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 700
                    // },
                    // {
                    //     id: 8,
                    //     name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent ipsum turpis, imperdiet id metus a, volutpat malesuada odio. Aliquam et leo odio.',
                    //     price: 800
                    // },
                ],
                bascketId: 0,
            }
        },

        methods: {
            closePopup() {
                this.$emit('closeTheCart')
            },

            removeItem(id) {
                this.products = this.products.filter(product => product.id != id)
                if (this.products.length == 0) this.$emit('closeTheCart')
            },
        },
    }
</script>

<style scoped>
    @import '../assets/css/material-design-forms.css';
    .popup-overlay {
        width: 100%;
        height: 100vh;
        position: fixed;
        top: 0px;
        left: 0px;
        z-index: 9;
        background: rgba(0,0,0,0.8);
    }
    .cart-form {
        background: #fff;
        -webkit-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        -moz-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        display: flex;
        justify-content: flex-start;
        align-items: flex-start;
        flex-direction: column;
        overflow: hidden;
        width: 750px;
        min-height: 520px;
        position: absolute;
        top: calc(50% - 315px);
        left: calc(50% - 375px);
        margin: 0px;
        padding: 20px 0px;
    }
    .cart-form .products-container {
        width: 700px;
        height: 450px;
        position: relative;
        display: flex;
        justify-content: flex-start;
        align-items: flex-start;
        flex-direction: column;
        overflow: auto;
        padding-left: 20px;
    }
    .cart-form .product-container {
        width: 95%;
        margin-right: 10px;
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 100px;
        overflow: hidden;
        position: relative;
        margin-bottom: 30px;
        padding-top: 30px;
    }
    .cart-form .product-container img {
        min-width: 100px;
        width: 100px;
        height: 100px;
        margin-bottom: 30px;
    }
    .cart-form .product-container .name {
        font-weight: 700;
        font-size: 16px;
        display: block;
        text-overflow: ellipsis;
        word-wrap: break-word;
        overflow: hidden;
        max-height: 60px;
        line-height: 20px;
        width: calc(100% - 20px);
        padding: 0px 10px;
        margin-bottom: 30px;
    }
    .cart-form .product-container .price {
        font-weight: 700;
        font-size: 24px;
        color: #41b883;
        margin-bottom: 30px;
        min-width: 100px;
    }
    .cart-form .product-container .btn {
        display: inline-flex;
        margin-bottom: 0;
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
        padding: 10px;
        margin-left: 20px;
        margin-bottom: 30px;
    }
    .cart-form .product-container .btn .remove {
        background: url('../assets/remove.png') center no-repeat;
        width: 24px;
        height: 24px;
        margin-left: 5px;
    }
    .cart-form .close-popup {
        position: absolute;
        top: 10px;
        right: 10px;
        font-weight: 700;
        color: #41b883;
        cursor: pointer;
    }
    .cart-form .cart-button {
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
    .cart-form .form-group {
        width: calc(100% - 80px);
    }
    .cart-form .form-group:first-child {
        margin-top: 0px;
    }
    .cart-form .button-container {
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        width: 100%;
        margin-top: 30px;
    }
</style>