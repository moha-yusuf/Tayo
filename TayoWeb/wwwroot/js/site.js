// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    var currentUrl = window.location.pathname;
    var navLinks = document.querySelectorAll('.navbar-nav .nav-link');
    var dropdownItems = document.querySelectorAll('.dropdown-menu .dropdown-item');
    var dropdownToggle = document.querySelector('.nav-item.dropdown .nav-link.dropdown-toggle');

    var activeFound = false;

    // Remove active class from all nav links and dropdown items
    navLinks.forEach(function (link) {
        link.classList.remove('active');
    });
    dropdownItems.forEach(function (item) {
        item.classList.remove('active');
    });
    dropdownToggle.classList.remove('active');

    // Check if the current URL matches any nav link
    navLinks.forEach(function (link) {
        if (link.getAttribute('href') === currentUrl) {
            link.classList.add('active');
            activeFound = true;
        }
    });

    // Check if the current URL matches any dropdown item
    var dropdownActive = false;
    dropdownItems.forEach(function (item) {
        if (item.getAttribute('href') === currentUrl) {
            dropdownActive = true;
        }
    });

    // Set active state for dropdown toggle
    if (dropdownActive) {
        dropdownToggle.classList.add('active');
    }

    // If no active link was found, set "Home" as active
    if (!activeFound && !dropdownActive) {
        var homeLink = document.querySelector('.navbar-nav .nav-link[href="/Customer/Home/Index"]');
        if (homeLink) {
            homeLink.classList.add('active');
        }
    }
});
