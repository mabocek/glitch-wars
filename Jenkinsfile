pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        withDotNet(sdk: '8.0') {
          dotnetNuGetLocals()
          dotnetClean()
          dotnetToolRestore()
          dotnetRestore()
          dotnetBuild()
          dotnetTest()
        }

      }
    }

    stage('Call pAIpline API') {
      steps {
        httpRequest(contentType: 'APPLICATION_JSON', acceptType: 'TEXT_PLAIN', url: 'http://xxxx/api/v1.0/OpenAI/jenkins-failed-build', consoleLogResponseBody: true, httpMode: 'POST', responseHandle: 'STRING')
      }
    }

  }
}