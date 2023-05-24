$(document).ready(function () {
   
    
   
    function DeleteAlert() {
        window.onload = function () {
            Swal.fire({
                title: "Entry Deleted",
                html:
                    '<div class="success-alert">' +
                    '<p class="success-message alert-success">Entry is successfully deleted!!</p>' +
                    '</div>',
                showCloseButton: true,
                showConfirmButton: false,
                icon: "success",
                timer: 10000, // Hide after 5 seconds
                timerProgressBar: true, // Show timer progress bar
            });
        };
        location.reload();
    }

    function ErrorAlert() {
        Swal.fire({
            title: "Try after sometime!!",
            html:
                '<div class="failure-alert">' +
                '<p class="failure-message">Some Technical Error.</p>' +
                '</div>',
            showCloseButton: true,
            icon: "error",
            showConfirmButton: false,
            timer: 8000, // Hide after 5 seconds
            timerProgressBar: true, // Show timer progress bar
        });
    }
    function DeleteFailAlert() {
        Swal.fire({
            title: "Failed in deleting entry",
            html:
                '<div class="failure-alert">' +
                '<p class="failure-message">Entry not Found!!</p>' +
                '</div>',
            showCloseButton: true,
            icon: "error",
            showConfirmButton: false,
            timer: 8000, // Hide after 5 seconds
            timerProgressBar: true, // Show timer progress bar
        });
    }
  
    $(document).on("click", "#deletebtn", function () {
        $("#deleteSkill").val($(this).val());
    })
   
    
   





    $(document).on("click", "#deleteSkill", function () {
        var id = $(this).attr("value");
        $.ajax({
            type: 'post',
            url: '/Skill/DeleteSkill',
            data: {
                'Id': id
            },
            success: function (result) {
                if (result) {
                    DeleteAlert();
                } 
                else {
                    ErrorAlert();
                }
            },
            error: function () {
                ErrorAlert();
            }
        })
    })
   
  

    $(document).on("click", "#cancelskill", function () {
        var $loader = $('<div class="loader"></div>'); // create loader element
    
        $("#ActiveContent").empty().append($loader); // show loader
        $.ajax({
            type: 'get',
            url: '/Skill/MissionSkills',
            success: function (result) {
              
                //newpagination.replaceWith(pagination);
                var html = $(result).find("#example_paginate").html;
                console.log(html);
                $("#ActiveContent").html(result);
            },
            error: function () {
                ErrorAlert();
            },
            complete: function () {
                $loader.remove(); // hide loader
            }
        });
    });
   
   
   
    
   
})
