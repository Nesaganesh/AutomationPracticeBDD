Feature: Update Account Info

    @UpdateAccountInfo
    Scenario: Update Account Name after logged in 
        Given I navigate to AutomationPractice website
        When I sign in with username 'nesa246@gmail.com' and password 'alex246#'
        Then I see account home page
        When I deeplink to my personal information page
        Then Update FirstName 'Alexraj' Password 'alex246#'
        And Save the information 
        Then Veriy the FirstName as 'Alexraj'