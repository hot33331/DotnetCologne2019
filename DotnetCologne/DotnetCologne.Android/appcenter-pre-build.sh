#!/usr/bin/env bash
#
# https://github.com/Microsoft/appcenter-build-scripts-examples
#
# For Xamarin, change some constants located in some class of the app.
# In this sample, suppose we have an AppConstant.cs class in shared folder with follow content:
#
# namespace Core
# {
#     public class AppConstant
#     {
#         public const string AppCenterKeyIos = "PLEASE_REPLACE_ME_APPCENTER";
#     }
# }
# 
# Suppose in our project exists two branches: master and develop. 
# We can release app for production API in master branch and app for test API in develop branch. 
# We just need configure this behaviour with environment variable in each branch :)
# 
# The same thing can be perform with any class of the app.
#
# AN IMPORTANT THING: FOR THIS SAMPLE YOU NEED DECLARE API_URL ENVIRONMENT VARIABLE IN APP CENTER BUILD CONFIGURATION.


if [ ! -n "$API_KEY_DROID" ]
then
    echo "You need define the $API_KEY_DROID variable in App Center"
    exit
fi

APP_CONSTANT_FILE=$APPCENTER_SOURCE_DIRECTORY/DotnetCologne/AppConstant.cs

if [ -e "$APP_CONSTANT_FILE" ]
then
    echo "Updating API_KEY_DROID to $API_KEY_DROID in AppConstant.cs"
    sed -i '' 's#AppCenterKeyDroid = "[-A-Za-z0-9:_./]*"#AppCenterKeyDroid = "'$API_KEY_DROID'"#' $APP_CONSTANT_FILE

    echo "File content:"
    cat $APP_CONSTANT_FILE
fi
