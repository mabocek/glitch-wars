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
  }

    post {
      failure {
        script {
          httpRequest(url: "http://${apiurl}/api/v1.0/CiCD/jenkins-failed-build", acceptType: 'TEXT_PLAIN', consoleLogResponseBody: true, contentType: 'APPLICATION_JSON', httpMode: 'POST', responseHandle: 'STRING')
        }
      }
    }
  
}
